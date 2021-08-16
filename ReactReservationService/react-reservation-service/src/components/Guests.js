/* eslint-disable react/require-render-return */
import { Tab } from 'bootstrap';
import React, {Component} from 'react';
import { Table } from 'react-bootstrap';

export class Guests extends Component {

    constructor(props) {
        super(props);
        this.state={deps:[]}
    }

    refreshList() {
        fetch(process.env.REACT_APP_API + 'Guests',{
            method: 'GET',
            mode: 'cors',
            headers: {
                'Accept': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
            },
        })
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
        return(
        <div>
            <Table className="mt-4 m-auto text-center" striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>NR REZEREACJI</th>
                        <th>IMIE</th>
                        <th>NAZWISKO</th>
                        <th>EMAIL</th>
                        <th>DATA URODZENIA</th>
                        <th>ADRES POCZTOWY</th>
                        <th>TELEFON</th>
                        <th>ADRES</th>
                        <th>MIASTO</th>
                    </tr>
                </thead>
                <tbody>
                    {deps.map((item) =>
                        <tr key={item.GuestId}>
                            <td>{item.GuestId}</td>
                            <td>{item.Reservation_ReservationId}</td>
                            <td>{item.Imie}</td>
                            <td>{item.Nazwisko}</td>
                            <td>{item.Email}</td>
                            <td>{item.Data_urodzenia}</td>
                            <td>{item.Adres_pocztowy}</td>
                            <td>{item.Telefon}</td>
                            <td>{item.Adres}</td>
                            <td>{item.Miasto}</td>
                        </tr>
                    )}
                </tbody>
            </Table>
        </div>
        )
    }
}