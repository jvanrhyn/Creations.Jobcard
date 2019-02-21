import React, { Component } from 'react';

export class LayerKind extends Component {

    constructor(props) {
        super(props);
        this.state = { layerKinds: [], loading: true };

        fetch('api/layerkind')
            .then(response => response.json())
            .then(data => {
                this.setState({ layerKinds: data, loading: false })
            });
    }

    static renderLayerKinds(layerKinds) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Power 1</th>
                        <th>Power 1 Min</th>
                        <th>Power 2</th>
                        <th>Power 2 Min</th>
                        <th>Speed</th>
                        <th>Acceleration</th>
                        <th>Corner</th>
                        <th>Scan gap</th>
                        <th>Blower</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        layerKinds.map(layerKind =>
                            <tr key={layerKind.id}>
                                <td>{layerKind.name}</td>
                                <td>{layerKind.power1}</td>
                                <td>{layerKind.power1Min}</td>
                                <td>{layerKind.power2}</td>
                                <td>{layerKind.power2Min}</td>
                                <td>{layerKind.speed}</td>
                                <td>{layerKind.acceleration}</td>
                                <td>{layerKind.corner}</td>
                                <td>{layerKind.scanGap}</td>
                                <td>{layerKind.blower ? 'Yes':'No'}</td>
                            </tr>
                        )
                    }
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : LayerKind.renderLayerKinds(this.state.layerKinds);

        return (
            <div>
                <h1>Layer kinds</h1>
                <p>This is a list of default layer kinds</p>
                {contents}
            </div>
        );
    }
}