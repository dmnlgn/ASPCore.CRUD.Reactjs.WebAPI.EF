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
                Imie: event.target.Imie.value,
                Nazwisko: event.target.Nazwisko.value,
                Email: event.target.Email.value,
                Data_urodzenia: event.target.Data_urodzenia.value,
                Adres_pocztowy: event.target.Adres_pocztowy.value,
                Telefon: event.target.Telefon.value,
                Miasto: event.target.Miasto.value,
                
                Reservation_ReservationId: event.target.Reservation_ReservationId.value,
            })
        })
        .then(res => res.json())
        .then((result)=>{
            alert("Dodano nowego gościa");
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
                            Dodaj Gościa
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col>
                                <Form onSubmit={this.handleSumbit}>
                                    <Form.Group className="mb-3" controlId="GuestId">
                                        <Form.Label>IMIE</Form.Label>
                                        <Form.Control required type="text" name="Imie" placeholder="Imie"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>NAZWISKO</Form.Label>
                                            <Form.Control required type="text" name="Nazwisko" placeholder="Nazwisko"/>
                                        </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>EMAIL</Form.Label>
                                        <Form.Control required type="text" name="Email" placeholder="Email"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>DATA URODZENIA</Form.Label>
                                        <Form.Control type="date" name="Data_urodzenia" placeholder="Data urodzenia"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>ADRES POCZTOWY</Form.Label>
                                        <Form.Control type="text" name="Adres_pocztowy" placeholder="Adres pocztowy"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>TELEFON</Form.Label>
                                        <Form.Control type="text" name="Telefon" placeholder="Telefon"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>ADRES</Form.Label>
                                        <Form.Control type="text" name="Adres" placeholder="Adres"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>MIASTO</Form.Label>
                                        <Form.Control type="text" name="Miasto" placeholder="Miasto"/>
                                    </Form.Group>
                                    <Form.Group className="mb-3">
                                        <Form.Label>REZERWACJA</Form.Label>
                                        <Form.Control type="text" name="Reservation_ReservationId" placeholder="Rezerwacja"/>
                                    </Form.Group>

                                    <Form.Group className="d-flex justify-content-between">
                                        <Button varian="primary" type="submit">Dodaj Gościa</Button>
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
