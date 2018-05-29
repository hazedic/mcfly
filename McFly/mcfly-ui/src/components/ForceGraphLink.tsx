import * as React from "react";

export interface Props {
  x1: number;
  y1: number;
  x2: number;
  y2: number;
}

export interface State {}

export default class ForceGraphLink extends React.PureComponent<Props, State> {
  constructor(props: Props, state: State) {
    super(props, state);
  }

  public render(): React.ReactNode {
    return (
      <line
        x1={this.props.x1}
        y1={this.props.y1}
        x2={this.props.x2}
        y2={this.props.y2}
      />
    );
  }
}
