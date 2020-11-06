var config = {
    userStore: new Oidc.WebStorageStateStore({ store: window.localStorage }),
    authority: "https://localhost:44355/",
    client_id: "WT.EcommerceClient_JS",
    response_type: "id_token token",
    redirect_uri: "https://localhost:44383/Home/signIn",
    scope: "openid EcommerceAdminAPI.admin WT.scope"
};


var userManager = new Oidc.UserManager(config);

var signIn = function () {
    userManager.signinRedirect();

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