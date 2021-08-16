/* eslint-disable react/require-render-return */
import React, {Component} from 'react';
import { Table } from 'react-bootstrap';

export class Reservations extends Component {

    constructor(props) {
        super(props);
        this.state={deps:[]}
    }

    refreshList() {
        fetch(process.env.REACT_APP_API + 'Reservations')
        .then(response => response.json())
        .then(data => {
            this.setState({deps: data})
        });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    render(){
        const {deps} = this.state;
        return (
            <div>
                <Table className="mt-4 m-auto text-center" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>KOD REZERWACJI</th>
                            <th>DATA UTWORZENIA</th>
                            <th>CENA</th> 
                            <th>DATA ZAMELDOWANIA</th>
                            <th>DATA WYMELDOWANIA</th>
                            <th>WALUTA</th>
                            <th>PROWIZJA</th>
                        </tr>
                    </thead>
                    <tbody>
                        {deps.map((item) =>
                            <tr key={item.ReservationId}>
                                <td>{item.ReservationId}</td>
                                <td>{item.Kod_Rezerwacji}</td>
                                <td>{item.Data_utworzenia}</td>
                                <td>{item.Cena}</td>
                                <td>{item.Data_zameldowania}</td>
                                <td>{item.Data_wymeldowania}</td>
                                <td>{item.Waluta}</td>
                                <td>{item.Prowizja}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </div>
        )
    }
}
