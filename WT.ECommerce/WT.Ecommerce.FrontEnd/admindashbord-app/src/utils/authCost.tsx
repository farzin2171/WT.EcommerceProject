import {WebStorageStateStore} from 'oidc-client'
debugger;
 const { REACT_APP_AUTHORITY,
         REACT_APP_CLIENT_ID,
         REACT_APP_RESPONSE_TYPE,
         REACT_APP_REDIRECT_URI,
         REACT_APP_POST_LOGOUT_REDIRECT_URI,
         REACT_APP_SCOPE}=process.env

export const IDENTITY_CONFIG={
    userStore: new WebStorageStateStore({ store: window.localStorage }),  //here we say where we can read data
    authority: REACT_APP_AUTHORITY,
    client_id: REACT_APP_CLIENT_ID,
    response_type: REACT_APP_RESPONSE_TYPE,
    redirect_uri: REACT_APP_REDIRECT_URI,
    post_logout_redirect_uri:REACT_APP_POST_LOGOUT_REDIRECT_URI,
    scope: REACT_APP_SCOPE
}