var config = {
    userStore: new Oidc.WebStorageStateStore({ store: window.localStorage }),  //here we say where we can read data
    authority: "https://localhost:44355/",
    client_id: "WT.EcommerceClient_JS",
    response_type: "code",
    redirect_uri: "https://localhost:44383/Home/signIn",
    post_logout_redirect_uri: "https://localhost:44383/Home/OidcPage",
    scope: "openid profile EcommerceAdminAPI.admin WT.scope"
};


var userManager = new Oidc.UserManager(config);

var signIn = function () {
    userManager.signinRedirect();

}

var signOut = function () {
    userManager.signoutRedirect();

}
userManager.getUser().then(user => {

    console.log("user:", user);
    if (user) {
        axios.defaults.headers.common["Authorization"] = "Bearer " + user.access_token;
    }
});

var callApi = function () {
    axios.get("https://localhost:44382/api/Secret")
        .then(res => {
            console.log(res);
        });
}

var refreshing = false;

//axios iterceptor 
axios.interceptors.response.use(
    function (response) { return response; },
    function (error) {
        console.log("axios error:", error.response);

        var axiosConfig = error.response.config;

        //if error response is 401 try to rfresh token
        if (error.response.status === 401) {
            console.log("axios error 401");

            //if already rfereshing don't make another request
            if (!refreshing) {
                refreshing = true;

              //do the refresh
                return userManager.signinSilent().then(user => {
                    console.log("new user:",user);
                    //update the http request and client
                    axios.defaults.headers.common["Authorization"] = "Bearer " + user.access_token;
                    axiosConfig.headers["Authorization"] = "Bearer " + user.access_token;
                   //retry the http request
                   return axios(axiosConfig);
                });

                
            }
           
        }
        return Promise.reject(error);
    });