import React from 'react'
import {Nav,Navbar,NavDropdown} from 'react-bootstrap'

type Props={

}

const Footer:React.FC<Props>=({
})=>{

    return (<div>
             <footer className="border-top footer text-muted">
              <div className="container">
                 &copy; 2020 - WT.Ecommerce
              </div>
             </footer>
            </div>)

};

export default Footer;
