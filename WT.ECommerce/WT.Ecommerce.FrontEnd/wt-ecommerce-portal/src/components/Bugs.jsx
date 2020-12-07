import React, { Component } from 'react'
import {callApi} from '../services/adminApis/secretAPI'

 export const Bugs=()=>{

     const publicApi=async()=>{
         debugger;
         const data=await callApi();
         console.log(data);
     }

    return (
     <div>
         <h1>
             <br/>
             <br/>
             <br/>
             <br/>
             <button onClick={publicApi}>Call API</button>
         </h1>
     </div>  
    );
 }

