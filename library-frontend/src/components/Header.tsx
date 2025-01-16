import React, { Component } from "react";
import {
  Navbar,
  NavbarBrand,
  Nav,
  NavLink,
  NavItem,
  Container,
  NavbarToggle,
  NavbarCollapse,
} from "react-bootstrap";

const Header = () => {
  return (
    <Navbar bg="dark" data-bs-theme="dark">
      <Container fluid>
        <Navbar.Brand href="/">Reading Tracker</Navbar.Brand>
        <NavbarToggle aria-controls="basic-navbar-nav"></NavbarToggle>
        <Navbar.Collapse aria-controls="basic-navbar-nav">
          <Nav className="me-auto">
            <NavItem>
              <NavLink href="/tracker/">Tracker</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/books/">Books</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/authors/">Authors</NavLink>
            </NavItem>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default Header;
