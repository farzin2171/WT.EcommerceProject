import axios from 'axios'
import AuthService from './authService';



const axiosInstance=axios.create({
    baseURL:process.env.REACT_APP_API_URL
});

const oidcStorage=JSON.parse(sessionStorage.getItem(`oidc.user:${process.env.REACT_APP_AUTHORITY}:${process.env.REACT_APP_CLIENT_ID}`));

if(oidcStorage && oidcStorage.access_token)
 {
      axiosInstance.defaults.headers.common["Authorization"] = "Bearer " + oidcStorage.access_token;
 }

 var refreshing = false;
 const authService=new AuthService();
//axios iterceptor 
axiosInstance.interceptors.response.use(
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
                return authService.hocSiginSilent(user=>{
                    debugger;
                    console.log("new user:",user);
                    //update the http request and client
                    axiosInstance.defaults.headers.common["Authorization"] = "Bearer " + user.access_token;
                    axiosConfig.headers["Authorization"] = "Bearer " + user.access_token;
                   //retry the http request
                   return axiosInstance(axiosConfig);
                });
            }
           
        }
        return Promise.reject(error);
    });

export default axiosInstance;