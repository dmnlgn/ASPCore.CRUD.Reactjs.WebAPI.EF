/* eslint-disable */
import { Button } from 'react-bootstrap';
import React, {Component} from 'react';

export class DropGuest extends Component {

    constructor(props) {
        super(props);
        this.DropGuest = this.DropGuest.bind(this);
    }

    DropGuest(event) {
        if(window.confirm("Jesteś pewien że chcesz usunąć wszystkich Piotrków?"))
        {
            event.preventDefault();
            const name = 'Piotr';
            fetch(process.env.REACT_APP_API + 'Guests/DropGuest/?name=' + name, {
                method: 'DELETE',
            })
            .then(res => res.json())
            .then((result)=>{
                alert("Wszystkie Piotrki zostały usunięte");
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
                onClick={this.DropGuest}>
                Usuń wszystkich Piotrków
            </Button>
            </div>
        );
    }
}
