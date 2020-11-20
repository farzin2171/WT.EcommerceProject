import React from 'react'
import {UserManager,WebStorageStateStore} from 'oidc-client'

type Props={

}

const SignIn:React.FC<Props>=({})=>{
    debugger;
    var userManger = new UserManager({
        userStore: new WebStorageStateStore({ store: window.localStorage }),  //here we say to Oidc where to save it
        response_mode:"query"
    });
    userManger.signinCallback().then(res => {
        console.log(res);
        window.location.href = '/';
    });
    return (<div className="pageBody"><h1>Sign In</h1></div>)

}

export default SignIn