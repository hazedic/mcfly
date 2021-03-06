import {
  forceCenter,
  forceLink,
  forceManyBody,
  forceSimulation,
  Simulation,
  SimulationLinkDatum,
  SimulationNodeDatum
} from "d3-force-3d";
import { ForceGraphLink, ForceGraphNode } from "../domain";
import { Simulator } from "./simulator";
import {
  EVENT_TYPE,
  EventData,
  IMyWorker,
  NewSimulationRequest,
  UpdateGraphDataRequest
} from "./types";

const ctx: IMyWorker = self as any;

let simulator: Simulator = null;


ctx.onmessage = event => {
  const eventData = event.data;
  switch (eventData.type) {
    case EVENT_TYPE.NEW_SIMULATION_REQUEST:
      console.log("[wr] NEW_SIMULATION_REQUEST");
      const newSimulationRequest = eventData.payload as NewSimulationRequest;
      simulator = new Simulator(
        newSimulationRequest.nodes,
        newSimulationRequest.links,
        ctx
      );
      break;
    case EVENT_TYPE.TICK_REQUEST:
      console.log("[wr] TICK_REQUEST");
      simulator.tick();
      break;
    case EVENT_TYPE.UPDATE_GRAPH_ELEMENTS_REQUEST:
      console.log("[wr] UPDATE_GRAPH_ELEMENTS_REQUEST");
      const updateGraphDataRequest = eventData.payload as UpdateGraphDataRequest;
      simulator.updateGraph(
        updateGraphDataRequest.addNodes,
        updateGraphDataRequest.removeNodes,
        updateGraphDataRequest.addLinks,
        updateGraphDataRequest.removeLinks
      );
      simulator.tick();
      break;
  }
};
