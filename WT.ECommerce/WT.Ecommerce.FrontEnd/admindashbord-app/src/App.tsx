import React from 'react';
import './App.css';
import { BrowserRouter } from "react-router-dom";
import {Routes} from "./Routes";
import Header from "./Components/Header"
import Footer from "./Components/Footer"


function App() {
  return (
    <div className="App">
        <Header></Header>
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
