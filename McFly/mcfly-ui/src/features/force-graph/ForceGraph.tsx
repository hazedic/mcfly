import {
  forceCenter,
  forceLink,
  forceManyBody,
  forceSimulation,
  Simulation,
  SimulationLinkDatum,
  SimulationNodeDatum
} from "d3-force-3d";
import {throttle} from "lodash";
import * as React from "react";
import {
  AmbientLight,
  BoxGeometry,
  BufferGeometry,
  Camera,
  Geometry,
  GridHelper,
  LightShadow,
  Line,
  LineBasicMaterial,
  Mesh,
  MeshBasicMaterial,
  MeshLambertMaterial,
  MeshPhongMaterial,
  OrbitControls,
  PerspectiveCamera,
  PlaneBufferGeometry,
  Renderer,
  Scene,
  ShadowMaterial,
  Sphere,
  SphereBufferGeometry,
  SphereGeometry,
  SpotLight,
  SpotLightShadow,
  TrackballControls as TrackballControlsType,
  Vector3,
  VRControls,
  WebGLRenderer
} from "three";
import DragControls from "three-dragcontrols";
import { ForceGraphElement, ForceGraphLink, ForceGraphNode } from "./domain";
import "./styles.scss";
const TrackballControls: any = require("three-trackballcontrols");

export interface Props {
  id: string;
  width: number;
  height: number;
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

export interface State {
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

type NodePair = [ForceGraphNode, ForceGraphNode];

export default class ForceGraph extends React.PureComponent<Props, State> {
  private spotlight: SpotLight;
  private webWorker: Worker;
  private containerDiv: HTMLDivElement;
  private simulation: Simulation<
    SimulationNodeDatum,
    SimulationLinkDatum<SimulationNodeDatum>
  >;
  private scene: Scene;
  private camera: PerspectiveCamera;
  private renderer: WebGLRenderer;
  private spheres: { [id: string]: Mesh };
  private lines: { [id: string]: Line };
  private trackballControls: TrackballControlsType;
  private dragControls:DragControls;
  private hasEnded = false;
  private numTicks = 180;
  private count = 0;  
  private vector1:Vector3 = new Vector3(0,0,0);
  private vector2:Vector3 = new Vector3(0,0,0);
  private debouncedUpdateControls: () => void;

  constructor(props: Props, state: State) {
    super(props, state);
    const ref = React.createRef();
  }

  public componentWillMount(): void {

    const newState: State = { nodes: this.props.nodes, links: this.props.links };
    this.setState(newState);

    this.simulation = forceSimulation(newState.nodes, 3)
      .force("charge", forceManyBody())
      .force("link", forceLink(newState.links))
      .force("center", forceCenter());
    this.simulation.stop();
  }

  public componentDidMount(): void {
    this.scene = new Scene();
    this.camera = new PerspectiveCamera(
      70,
      this.props.width / this.props.height,
      1,
      10000
    );
    this.camera.position.set(0, 250, 1000);
    this.renderer = new WebGLRenderer({
      antialias: true
    });

    this.trackballControls = new TrackballControls(this.camera);
    this.trackballControls.rotateSpeed = 1.0;
    this.trackballControls.zoomSpeed = 1.2;
    this.trackballControls.panSpeed = 0.8;
    this.trackballControls.noZoom = false;
    this.trackballControls.noPan = false;
    this.trackballControls.noRotate = false;
    this.trackballControls.staticMoving = true;
    this.trackballControls.dynamicDampingFactor = 0.3;
    this.trackballControls.keys = [65, 83, 68];
    this.debouncedUpdateControls = throttle(this.trackballControls.update, 100)

    this.renderer.setClearColor(0xf0f0f0);
    this.renderer.setPixelRatio(window.devicePixelRatio);
    this.renderer.setSize(this.props.width, this.props.height);
    this.renderer.shadowMap.enabled = true;
    this.containerDiv.appendChild(this.renderer.domElement);
    const geometry = new SphereBufferGeometry(10);
    const material = new MeshBasicMaterial({ color: "#433F81" });
    this.scene.add(new AmbientLight(0xbbbbbb));

    const light = new SpotLight(0xffffff, 1.5);
    light.position.set(0, 1500, 200);
    light.castShadow = true;
    light.shadow = new SpotLightShadow(new PerspectiveCamera(70, 1, 200, 2000));
    light.shadow.bias = -0.000222;
    light.shadow.mapSize.width = 1024;
    light.shadow.mapSize.height = 1024;
    this.scene.add(light);
    this.spotlight = light;

    const planeGeometry = new PlaneBufferGeometry(2000, 2000);
    planeGeometry.rotateX(-Math.PI / 2);
    const planeMaterial = new ShadowMaterial({ opacity: 0.2 });
    const plane = new Mesh(planeGeometry, planeMaterial);
    plane.position.y = -200;
    plane.receiveShadow = true;
    this.scene.add(plane);
    const helper = new GridHelper(2000, 100);
    helper.position.y = -199;
    helper.material.opacity = 0.25;
    helper.material.transparent = true;
    this.scene.add(helper);
    const objects: Mesh[] = [];

    this.spheres = {};
    this.state.nodes.forEach((e, i) => {
      this.spheres[e.id] = new Mesh(geometry, material);
      this.scene.add(this.spheres[e.id]);
      objects.push(this.spheres[e.id]);
    });

    
    const lineMaterial = new LineBasicMaterial({
      color: 0x0000ff,
      linewidth: 10
    });
    this.lines = {};
    this.state.links.forEach((e, i) => {
      const lineGeometry = new BufferGeometry();
      const sourceId = e.source.id;
      const targetId = e.target.id;
      const sourceObj = this.spheres[sourceId];
      const targetObj = this.spheres[targetId];
      lineGeometry.setFromPoints([ 
        new Vector3(sourceObj.position.x, sourceObj.position.y, sourceObj.position.z),
        new Vector3(targetObj.position.x, targetObj.position.y, targetObj.position.z)
      ]);
      this.lines[e.id] = new Line(lineGeometry, lineMaterial);
      this.scene.add(this.lines[e.id]);
    });

    this.dragControls = new DragControls(objects, this.camera, this.renderer.domElement);
    this.dragControls.addEventListener("dragstart", e => this.trackballControls.enabled = false);
    this.dragControls.addEventListener("dragend", e => this.trackballControls.enabled = true);

    (window as any).scene = this.scene;
    this.animate();
    this.renderFrame();
  }

  public render(): React.ReactNode {
    return <div ref={node => (this.containerDiv = node)} />;
  }

  private animate = () => {
    
    requestAnimationFrame(this.animate);
    if(this.count++ > this.numTicks)
    {
      this.hasEnded = true;
    }
    if(!this.hasEnded) {    
    this.simulation.tick();      
      this.simulation.nodes().forEach((e, i) => {
        this.spheres[e.id].position.set(e.x || 0, e.y || 0, e.z || 0);
      });
    }
    
    this.state.links.forEach((e, i) => {
      const line = this.lines[e.id];
      const sourceId = e.source.id;
      const targetId = e.target.id;
      const sourceObj = this.spheres[sourceId];
      const targetObj = this.spheres[targetId];
      this.vector1.x = sourceObj.position.x;
      this.vector2.x = targetObj.position.x;
      this.vector1.y = sourceObj.position.y;
      this.vector2.y = targetObj.position.y;
      this.vector1.z = sourceObj.position.z;
      this.vector2.z = targetObj.position.z;
      line.geometry.setFromPoints([
        this.vector1,
        this.vector2
      ]);
    });

    this.debouncedUpdateControls();
    this.renderFrame();
  };

  private renderFrame = () => {
    this.renderer.render(this.scene, this.camera);
  };
}
