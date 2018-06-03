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
  PerspectiveCamera,
  Scene,
  WebGLRenderer,
  Camera,
  Renderer
} from "three";
import { ForceGraphElement, ForceGraphLink, ForceGraphNode } from "./domain";

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
  private webWorker: Worker;
  private canvasRef: React.RefObject<HTMLDivElement>;
  private simulation: Simulation<
    SimulationNodeDatum,
    SimulationLinkDatum<SimulationNodeDatum>
  >;
  private scene: Scene;
  private camera: Camera;
  private renderer: WebGLRenderer;
  constructor(props: Props, state: State) {
    super(props, state);
    const ref = React.createRef();
  }

  public componentWillMount(): void {
    this.setState({ nodes: [], links: [] });
    const nodes: SimulationNodeDatum[] = this.state.nodes.map(n => {
      return { id: n.id } as any;
    });
    const links: Array<
      SimulationLinkDatum<SimulationNodeDatum>
    > = this.state.links.map(l => {
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
      75,
      this.props.width / this.props.height,
      0.1,
      1000
    );
    this.camera.position.z = 4;
    this.renderer = new WebGLRenderer({
      antialias: true
    });
    this.renderer.setClearColor("#000000");
    this.renderer.setSize(this.props.width, this.props.height);

    this.canvasRef.current.appendChild(this.renderer.domElement);
  }

  public render(): React.ReactNode {
    return <div ref={this.canvasRef} />;
  }
}
