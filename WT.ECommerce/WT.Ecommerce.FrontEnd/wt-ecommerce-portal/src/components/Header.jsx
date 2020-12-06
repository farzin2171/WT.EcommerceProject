import React,{useContext} from 'react'
import {Nav,Navbar,NavDropdown} from 'react-bootstrap'
import {AuthContext} from '../providers/authProvider'


export const Header =()=>{
    // const {getUser}=useContext(AuthContext);
    //  getUser().then(user=>{
    //      console.log(user);
    //  });
    
  return (
      <div>
          <header>
                  <Navbar bg="primary" variant="dark" expand="lg" fixed="top">
                     <Navbar.Brand href="#">WT Ecommerce Dashboard</Navbar.Brand>
                     <Navbar.Toggle aria-controls="responsive-navbar-nav"  />
                     <Navbar.Collapse id="responsive-navbar-nav">
                       <Nav className="mr-auto">
                          <Nav.Link href="#home">Home</Nav.Link>
                          <Nav.Link href="/dashbord">Products</Nav.Link>
                          <Nav.Link href="/logout">Log Out</Nav.Link>

                       </Nav>
                     </Navbar.Collapse>
                  </Navbar>
              </header>
      </div>
  )
}
