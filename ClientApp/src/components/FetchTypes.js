import React, { Component } from 'react';

export class FetchTypes extends Component {
    static displayName = FetchTypes.name;

    constructor(props) {
        super(props);
        this.state = { types: [], loading: true };
    }

    componentDidMount() {
        this.populateTypesData();
    }

    static renderTypesTable(types) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Type</th>
                    </tr>
                </thead>
                <tbody>
                    {types.map(t =>
                        <tr key={t}>
                            <td>{t}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchTypes.renderTypesTable(this.state.types);

        return (
            <div>
                <h1 id="tabelLabel" >Pokemon Types</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateTypesData() {
        const response = await fetch('types');
        const data = await response.json();
        this.setState({ types: data, loading: false });
    }
}
