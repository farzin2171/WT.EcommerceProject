import React from 'react'
import {Nav,Navbar,NavDropdown} from 'react-bootstrap'
import {AuthConsumer} from '../providers/authProvider'


export const Header =()=>{
  return (
      <div>
          <header>
                  <Navbar bg="primary" variant="dark" expand="lg" fixed="top">
                     <Navbar.Brand href="#home">WT Ecommerce Dashboard</Navbar.Brand>
                     <Navbar.Toggle aria-controls="responsive-navbar-nav"  />
                     <Navbar.Collapse id="responsive-navbar-nav">
                       <Nav className="mr-auto">
                         <Navbar.Text>
                           <span> Welcome </span>
                         </Navbar.Text>
                       </Nav>
                       <Nav>
                              <NavDropdown title="Products" id="collasible-nav-dropdown">
                                 <NavDropdown.Item href="#">Change Language</NavDropdown.Item>
                                 <NavDropdown.Item href="/apply/search">Latest Apllications</NavDropdown.Item>
                                 <NavDropdown.Item href="#">Create</NavDropdown.Item>
                              </NavDropdown>
                       </Nav>
                     </Navbar.Collapse>
                  </Navbar>
              </header>
      </div>
  )
}
