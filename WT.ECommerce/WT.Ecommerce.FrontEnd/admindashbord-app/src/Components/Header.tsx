import React,{useState,useEffect} from 'react'
import {Nav,Navbar,NavDropdown} from 'react-bootstrap'
import {UserManager} from 'oidc-client'
import {IDENTITY_CONFIG} from '../utils/authCost'

type Props={
  isLoggedIn:boolean,
  userName:string
}

const Header:React.FC<Props>=({
    isLoggedIn,
    userName
})=>{
   
    let userManager=new UserManager(IDENTITY_CONFIG)
    var signIn=()=>{
        userManager.signinRedirect();
    }

    var signOut=()=>{
        userManager.getUser()
        .then(user => {
            if (user) {
                return userManager.signoutRedirect();
            } else {
               
                return user;
            }
        })
        .catch(() => {
            
        });
    }

    return (<div>
              <header>
                  <Navbar bg="light" variant="light" expand="lg" fixed="top">
                     <Navbar.Brand href="#home">WT.Ecommerec</Navbar.Brand>
                     <Navbar.Toggle aria-controls="responsive-navbar-nav"  />
                     <Navbar.Collapse id="responsive-navbar-nav">
                       <Nav className="mr-auto">
                         <Navbar.Text>
                           <span> {isLoggedIn?  (<span>Welcome  {userName}</span>):null }</span>
                         </Navbar.Text>
                       </Nav>
                       <Nav>
                              <NavDropdown title="Product" id="collasible-nav-dropdown">
                                 <NavDropdown.Item href="/products">Product List</NavDropdown.Item>
                                 <NavDropdown.Item href="/">New Product</NavDropdown.Item>
                                 <NavDropdown.Item href="/">Product Categories</NavDropdown.Item>
                              </NavDropdown>
                              {!isLoggedIn? <a className="nav-link text-dark" href="#" onClick={signIn}><span className="glyphicon glyphicon-log-in">&nbsp;</span>Login</a> :null}
                              {isLoggedIn? <a className="nav-link text-dark" href="#" onClick={signOut}><span className="glyphicon glyphicon-log-in">&nbsp;</span>Sign Out</a> :null}  
                       </Nav>
                     </Navbar.Collapse>
                  </Navbar>
              </header>
            </div>)

};

export default Header;
