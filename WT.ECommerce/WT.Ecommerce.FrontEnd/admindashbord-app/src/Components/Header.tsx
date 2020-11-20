import React,{useState,useEffect} from 'react'
import {Nav,Navbar,NavDropdown} from 'react-bootstrap'
import {UserManager} from 'oidc-client'
import {IDENTITY_CONFIG} from '../utils/authCost'

type Props={

}

const Header:React.FC<Props>=({
})=>{
    console.log(IDENTITY_CONFIG);
    let userManager=new UserManager(IDENTITY_CONFIG)
    var signIn=()=>{
        debugger;
        userManager.signinRedirect();
    }
    return (<div>
              <header>
                  <Navbar bg="light" variant="light" expand="lg" fixed="top">
                     <Navbar.Brand href="#home">WT.Ecommerec</Navbar.Brand>
                     <Navbar.Toggle aria-controls="responsive-navbar-nav"  />
                     <Navbar.Collapse id="responsive-navbar-nav">
                       <Nav className="mr-auto">
                         <Navbar.Text>
                            
                         </Navbar.Text>
                       </Nav>
                       <Nav>
                              <NavDropdown title="Product" id="collasible-nav-dropdown">
                                 <NavDropdown.Item href="/dashboard">Product List</NavDropdown.Item>
                                 <NavDropdown.Item href="/">New Product</NavDropdown.Item>
                                 <NavDropdown.Item href="/">Product Categories</NavDropdown.Item>
                              </NavDropdown>
                              <a className="nav-link text-dark" href="#" onClick={signIn} >Login</a>
                       </Nav>
                     </Navbar.Collapse>
                  </Navbar>
              </header>
            </div>)

};

export default Header;
