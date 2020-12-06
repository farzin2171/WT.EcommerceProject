import {IDENTITY_CONFIG} from '../utils/authConst';
import {UserManager,WebStorageStateStore,Log} from 'oidc-client'

export default class AuthService{
    UserManager;

    constructor(){
        this.UserManager=new UserManager({
            ...IDENTITY_CONFIG,
            userStore:new WebStorageStateStore({store:window.sessionStorage})
        });

        //Logger
        Log.logger=console;
        Log.level=Log.DEBUG;

        this.UserManager.events.addUserLoaded((user)=>{
            if(window.location.href.indexOf("signin-oidc") !== -1){
                this.navigateToScreen();
            }

        });

        this.UserManager.events.addSilentRenewError((error)=>{
            console.log('silent renew error',error.message);
        })

        this.UserManager.events.addAccessTokenExpired(()=>{
            console.log("token expired");
            this.signinSilent();

        });

    }

    //Methods
    navigateToScreen=()=>{
        window.location.replace("/dashbord");
    };

    signinSilent=()=>{
        this.UserManager.signinSilent()
        .then((user)=>{
            console.log("sign in",user);
        })
        .catch((error)=>{
            console.log(error);
        });
    };

    signinSilentCallback=()=>{
        this.UserManager.signinSilentCallback();
    };

    createSigninRequest=()=>{
        return this.UserManager.createSigninRequest();
    }

    signinRedirectCallback=()=>{
        debugger;
        this.UserManager.signinRedirectCallback().then(()=>{
            "";
        });
    };

    getUser=async()=>{
    
        const user=await this.UserManager.getUser();
        if(!user){
            return await this.UserManager.signinRedirectCallback();
        }

        return user;
    };

    parseJwt=(token)=>{
        const base64Url=token.split(".")[1];
        const base64=base64Url.replace("-","+").replace("_","/");
        return JSON.parse(window.atob(base64));
    };

    signinRedirect=()=>{
        debugger;
        localStorage.setItem("redirectUri",window.location.pathname);
        this.UserManager.signinRedirect({});
    }

    isAuthenticated=()=>{
        debugger;
        console.log('isAuthenticated called')
        const oidcStorage=JSON.parse(sessionStorage.getItem(`oidc.user:${process.env.REACT_APP_AUTHORITY}:${process.env.REACT_APP_CLIENT_ID}`));

        return (!!oidcStorage && !!oidcStorage.access_token);
    }

    logout=()=>{
        this.UserManager.signoutRedirect({
            id_token_hint:localStorage.getItem("id_token")
        });

        UserManager.clearStaleState();
    }

    signoutRedirectCallback=()=>{
        this.UserManager.signoutRedirectCallback().then(()=>{
            localStorage.clear();
            window.location.replace(process.env.REACT_APP_PUBLIC_URL);
        });

        this.UserManager.clearStaleState();
    }

}
