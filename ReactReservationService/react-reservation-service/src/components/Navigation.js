/* eslint-disable react/require-render-return */
import React, {Component} from 'react';
import { NavLink } from 'react-router-dom';
import { Navbar, Nav } from 'react-bootstrap';

export class Navigation extends Component{
    render(){
        return(
            <Navbar bg="dark" expanded="lg">
                <Navbar aria-controls="basic-navbar-nav"/>
                <Navbar id="basic-navbar-nav" className="m-auto">
                    <Nav>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                            Strona główna
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/reservations">
                            Rezerwacje
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/guests">
                            Goście
                        </NavLink>
                    </Nav>
                </Navbar>
            </Navbar>
        )
    }
}
