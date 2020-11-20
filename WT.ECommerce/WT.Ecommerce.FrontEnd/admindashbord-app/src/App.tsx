import React,{useState,useEffect} from 'react';
import './App.css';
import { BrowserRouter } from "react-router-dom";
import {Routes} from "./Routes";
import Header from "./Components/Header"
import Footer from "./Components/Footer"
import {IDENTITY_CONFIG} from './utils/authCost'
import {UserManager} from 'oidc-client'


function App() {
  const [loggedIn,setLoggedIn]=useState(false);
  const [userName,setUserName]=useState("");
  const [loading,setLoading]=useState(true);

  useEffect(() => {
    setuserInfo();
  }, []);

  var setuserInfo=async ()=>{
    setLoading(true);
    var userManager = new UserManager(IDENTITY_CONFIG);
    
    userManager.getUser().then(user => {
        if(user)
        {
          console.log(user)
          setLoggedIn(true);
          var username=user.profile.name ? user.profile.name.toString():"";
          setUserName(username);
        }
        else
        {
          setLoggedIn(false);
        }
          
       setLoading(false);

    });
  }

  return (
    <div className="App">
        <Header isLoggedIn={loggedIn} userName={userName}></Header>
        <div className="container">
          <main role="main" className="pb-3">
            <BrowserRouter children={Routes} basename={"/"} />
          </main>
        </div>
        <Footer></Footer>
    </div>
  );
}

export default App;
