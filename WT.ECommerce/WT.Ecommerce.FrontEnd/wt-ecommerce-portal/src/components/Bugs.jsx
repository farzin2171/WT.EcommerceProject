import React, { Component,useState } from 'react'
import {callApi,submitFile} from '../services/adminApis/secretAPI'

 export const Bugs=()=>{
     
     const[files,setFiles]=useState([]);
     
     const uploadJustFile=(e)=> {
        e.preventDefault();
        
        let form = new FormData();
        for (var index = 0; index < files.length; index++) {
            var element = files[index];
            form.append('file', element);
        }
        submitFile(form);
    };

     const filesOnChange=(sender)=> {
        let files = sender.target.files;
        setFiles(files);
    }



    return (
     <div>
         <h1>
             <br/>
             <br/>
              <input type="file" id="case-one" onChange={filesOnChange} />
                 <br />
              <button type="text" onClick={uploadJustFile}>Upload just file</button>              
         </h1>
     </div>  
    );
 }

