import React, {Component} from 'react';
import { NavLink } from 'react-router-dom';
import { Nav,Navbar } from 'react-bootstrap';

export class Navigation extends Component {
    render(){
        return(
           <Navbar bg='dark' expand='lg'>
               <Navbar.Toggle area-controls="basic-navbar-nav"/>
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav>
                            <NavLink className="d-inline p-2 pg-dark text-white" to="/home">
                                Home
                            </NavLink>
                            <NavLink className="d-inline p-2 pg-dark text-white" to="/department">
                                Department
                            </NavLink>
                            <NavLink className="d-inline p-2 pg-dark text-white" to="/employee">
                                Employee
                            </NavLink>
                        </Nav>
                    </Navbar.Collapse>
        
           </Navbar>
        )
    }
}