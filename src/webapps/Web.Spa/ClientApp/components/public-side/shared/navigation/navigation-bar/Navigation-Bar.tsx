import React from "react";
import { withRouter } from "react-router";
import { Nav, Navbar } from "react-bootstrap";
import { LinkContainer } from 'react-router-bootstrap'
import ProjectTitle from "@Components/redux/containers/project-detail/Project-Title";

/**
 * @function NavigationBar Display main navigation on public side.
 * @returns JSX with main public side navigation.
 */
const NavigationBar: React.FC = () => {
    return (
        <Navbar bg="light" expand="lg">
            <LinkContainer exact to={'/'}>
                <Navbar.Brand>
                    <ProjectTitle />
                </Navbar.Brand>
            </LinkContainer>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="mr-auto">
                    <LinkContainer exact to={'/'}>
                        <Nav.Link>Home</Nav.Link>
                    </LinkContainer>
                    <LinkContainer exact to={'/products'}>
                        <Nav.Link>Products</Nav.Link>
                    </LinkContainer>

                    <LinkContainer exact to={'/cart'}>
                        <Nav.Link>Cart</Nav.Link>
                    </LinkContainer>

                    <LinkContainer exact to={'/orders'}>
                        <Nav.Link>Orders</Nav.Link>
                    </LinkContainer> 

                    <LinkContainer exact to={'/contact'}>
                        <Nav.Link>Contact</Nav.Link>
                    </LinkContainer> 
                </Nav>
            </Navbar.Collapse>
    </Navbar>);
}

// Attach the React Router to the component to have an opportunity
// to interract with it: use some navigation components, 
// have an access to React Router fields in the component's props, etc.
export default withRouter(NavigationBar);