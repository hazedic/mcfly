import {
  forceCenter,
  forceLink,
  forceManyBody,
  forceSimulation,
  Simulation,
  SimulationLinkDatum,
  SimulationNodeDatum
} from "d3-force-3d";
import * as React from "react";
import {
  AmbientLight,
  BoxGeometry,
  Camera,
  GridHelper,
  LightShadow,
  Mesh,
  MeshBasicMaterial,
  MeshPhongMaterial,
  OrbitControls,
  PerspectiveCamera,
  PlaneBufferGeometry,
  Renderer,
  Scene,
  ShadowMaterial,
  Sphere,
  SphereGeometry,
  SpotLight,
  SpotLightShadow,
  TrackballControls as TrackballControlsType,
  VRControls,
  WebGLRenderer
} from "three";

import { ForceGraphElement, ForceGraphLink, ForceGraphNode } from "./domain";
import "./styles.scss";

const TrackballControls:any = require("three-trackballcontrols");

export interface Props {
  id: string;
  width: number;
  height: number;
}

export interface State {
  nodes: ForceGraphNode[];
  links: ForceGraphLink[];
}

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
  private trackballControls: TrackballControlsType;
  constructor(props: Props, state: State) {
    super(props, state);
    const ref = React.createRef();
  }

  public componentWillMount(): void {
    const nodesData: ForceGraphNode[] = [
      {
        id: "a",
        title: "The letter a"
      },
      {
        id: "b",
        title: "The letter b"
      },
      {
        id: "c",
        title: "The letter c"
      },
      {
        id: "d",
        title: "The letter d"
      },
      {
        id: "e",
        title: "The letter e"
      },
      {
        id: "f",
        title: "The letter f"
      }
    ];
    const linksData: ForceGraphLink[] = [];
    const newState: State = { nodes: nodesData, links: linksData };
    this.setState(newState);
    const nodes: SimulationNodeDatum[] = newState.nodes.map(n => {
      return { id: n.id } as any;
    });
    const links: Array<
      SimulationLinkDatum<SimulationNodeDatum>
    > = newState.links.map(l => {
      return { source: l.from, target: l.to } as any;
    });
    this.simulation = forceSimulation(nodes)
      .force("charge", forceManyBody())
      .force("link", forceLink(links))
      .force("center", forceCenter());
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
    this.trackballControls.panSpeed = .8;
    this.trackballControls.noZoom = false;
    this.trackballControls.noPan = false;
    this.trackballControls.noRotate = false;
    this.trackballControls.staticMoving = true;
    this.trackballControls.dynamicDampingFactor = .3;
    this.trackballControls.keys = [65, 83, 68];
    this.trackballControls.addEventListener('change', this.renderFrame);

    this.renderer.setClearColor(0xf0f0f0);
    this.renderer.setPixelRatio(window.devicePixelRatio);
    this.renderer.setSize(this.props.width, this.props.height);
    this.renderer.shadowMap.enabled = true;
    this.containerDiv.appendChild(this.renderer.domElement);
    const geometry = new SphereGeometry(10);
    const material = new MeshPhongMaterial({ color: "#433F81" });
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


    this.spheres = {};
    this.state.nodes.forEach((e, i) => {
      this.spheres[e.id] = new Mesh(geometry, material);
      this.scene.add(this.spheres[e.id]);
    });
    (window as any).scene = this.scene;
    this.animate();    
    this.renderFrame();
  }

  public render(): React.ReactNode {
    return <div ref={node => (this.containerDiv = node)} />;
  }

  private animate = () => {
    requestAnimationFrame(this.animate);
    this.simulation.nodes().forEach((e, i) => {
      this.spheres[e.id].position.set(e.x || 0, e.y || 0, e.z || 0);
    });
    this.trackballControls.update();  
    this.renderFrame();  
  }

  private renderFrame = () => {
    this.renderer.render(this.scene, this.camera);
  };
}
