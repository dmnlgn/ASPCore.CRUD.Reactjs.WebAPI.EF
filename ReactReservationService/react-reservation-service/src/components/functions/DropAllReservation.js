/* eslint-disable */

import { Button } from 'react-bootstrap';
import React, {Component} from 'react';
import { Table } from 'react-bootstrap';

export class DropAllReservations extends Component {

    constructor(props) {
        super(props);
        this.DropReservations = this.DropReservations.bind(this);
    }

    DropReservations(event) {
        if(window.confirm("Jesteś pewien że chcesz usunąć wszystkie Rezerwacje?"))
        {
            event.preventDefault();
            fetch(process.env.REACT_APP_API + 'Reservations/DropReservations', {
                method: 'DELETE',
            })
            .then(res => res.json())
            .then((result)=>{
                alert("Wszystkie rezerwacje zostały usunięte");
                console.log(result);
            },
            (error)=>{
                alert("Błąd");
            })
        }
    }

    render(){
        return (
            <div>
            <Button 
                variant="primary" 
                size="sm" 
                onClick={this.DropReservations}>
                Usuń wszystkie rezerwacje
            </Button>
            </div>
        );
    }
}
