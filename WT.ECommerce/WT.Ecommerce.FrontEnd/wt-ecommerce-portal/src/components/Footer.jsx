import React from 'react'
import {Nav,Navbar} from 'react-bootstrap'


export const Footer =()=>{
    
  return (
      <div>
          <header>
                  <Navbar bg="primary" variant="dark" expand="lg" fixed="bottom">
                       <Nav className="mr-auto">
                            <Navbar.Text>
                               Footer
                            </Navbar.Text>
                       </Nav>
                  </Navbar>
              </header>
      </div>
  )
}
