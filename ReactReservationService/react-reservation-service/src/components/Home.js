import React, {Component} from 'react';
import { DropAllReservations } from './functions/DropAllReservation';
import { DropGuest } from './functions/DropGuest';
import { ButtonToolbar, ButtonGroup, Button } from 'react-bootstrap';
import { AddReservation } from './functions/AddReservation';
import '../App.css';

export class Home extends Component {

    constructor(props) {
        super(props);
        this.state={AddReservationShow: false};
    }

    render(){
        let addReservationClose = () => this.setState({AddReservationShow:false})
        return (
        <div className="mt-5 d-flex justify-content-center">
        <ButtonToolbar>
            <ButtonGroup className="button-gap">
                <DropAllReservations/>
                <DropGuest/>
                <AddReservation/>
                <Button
                    variant='primary'
                    onClick = {() => this.setState({AddReservationShow:true})}
                    size='sm'>
                    Dodaj nową rezerwację
                </Button>
                <AddReservation show={this.state.AddReservationShow}
                onHide={addReservationClose}/>
            </ButtonGroup>
        </ButtonToolbar>
        </div>
        )
    }
}