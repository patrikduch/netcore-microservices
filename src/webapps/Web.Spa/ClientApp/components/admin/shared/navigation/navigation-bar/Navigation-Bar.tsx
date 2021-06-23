import ProjectTitle from '@Components/redux/containers/project-detail/Project-Title';
import React from 'react';
import { Nav, Navbar } from "react-bootstrap";
import { LinkContainer } from 'react-router-bootstrap'

import './Navigation-Bar.scss';

/**
 * @function NavigationBar Display administration navigation bar.
 * @returns JSX for displaying administration navigation bar.
 */
const NavigationBar: React.FC = () => {
    return (
        <>
            <Navbar bg="light" expand="lg">
                <LinkContainer exact to={'/admin'}>
                    <Navbar.Brand>
                        <ProjectTitle />
                    </Navbar.Brand>
                </LinkContainer>
                
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="mr-auto">
                        <LinkContainer exact to={'/admin/customers'}>
                            <Nav.Link>Customers</Nav.Link>
                        </LinkContainer>
                        
                        <LinkContainer exact to={'/admin/products'}>
                            <Nav.Link>Products</Nav.Link>
                        </LinkContainer>

                    </Nav>
            </Navbar.Collapse>
        </Navbar>
        </>
    );
}

export default NavigationBar;