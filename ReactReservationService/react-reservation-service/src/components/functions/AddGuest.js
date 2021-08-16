/* eslint-disable */

import { Button, Form } from 'react-bootstrap';
import React, {Component} from 'react';
import { Modal, Row, Col } from 'react-bootstrap';

export class AddGuest extends Component {

    constructor(props) {
        super(props);
        this.handleSumbit = this.handleSumbit.bind(this);
    }

    handleSumbit(event) {
        event.preventDefault();
        fetch(process.env.REACT_APP_API + 'Guests/CreateReservation', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
              },
            body:JSON.stringify({
                Kod_Rezerwacji: event.target.Kod_Rezerwacji.value,
                Data_utworzenia: event.target.Data_utworzenia.value,
                Cena: event.target.Cena.value,
                Data_zameldowania: event.target.Data_zameldowania.value,
                Data_wymeldowania: event.target.Data_wymeldowania.value,
                Waluta: event.target.Waluta.value,
                Prowizja: event.target.Prowizja.value,    
            })
        })
        .then(res => res.json())
        .then((result)=>{
            alert("Dodano nową rezerwację");
            console.log(result);
        },
        (error)=>{
            alert("Błąd");
        })
    }

    render(){
        return (
            <div>
                <Modal
                   {...this.props}
                    size="sm"
                    aria-labelledby="contained-modal-title-vcenter"
                    centered>
                    <Modal.Header>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Dodaj Rezerwację
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col>
                                <Form onSubmit={this.handleSumbit}>
                                    <Form.Group className="mb-3" controlId="KodRezerwacji">
                                        <Form.Label>KOD REZERWACJI</Form.Label>
                                        <Form.Control required maxLength="10"  type="text" name="Kod_Rezerwacji" placeholder="Kod rezerwacji"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>DATA UTWORZENIA</Form.Label>
                                            <Form.Control required type="date" name="Data_utworzenia" placeholder="Data utworzenia"/>
                                        </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>CENA</Form.Label>
                                        <Form.Control required type="text" name="Cena" placeholder="Cena"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>DATA ZAMELDOWANIA</Form.Label>
                                        <Form.Control required type="date" name="Data_zameldowania" placeholder="Data zameldowania"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>DATA WYMELDOWANIA</Form.Label>
                                        <Form.Control required type="date" name="Data_wymeldowania" placeholder="Data wymeldowania"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>WALUTA</Form.Label>
                                        <Form.Control required type="text" name="Waluta" placeholder="Waluta"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>PROWIZJA</Form.Label>
                                        <Form.Control type="text" name="Prowizja" placeholder="Prowizja"/>
                                    </Form.Group>

                                    <Form.Group className="d-flex justify-content-between">
                                        <Button varian="primary" type="submit">Dodaj Rezerwację</Button>
                                        <Button variant="danger" onClick={this.props.onHide}>Zamknij</Button>
                                    </Form.Group>
                                </Form>
                            </Col>
                        </Row>
                    </Modal.Body>
                </Modal>
            </div>
        );
    }
}
