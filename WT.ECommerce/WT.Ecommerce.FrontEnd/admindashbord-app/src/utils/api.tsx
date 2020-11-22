import axios from 'axios'


const {REACT_APP_ADMIN_API_BASEURL} = process.env

const axiosInstanc=  axios.create({
    baseURL:REACT_APP_ADMIN_API_BASEURL,
    
});
console.log(localStorage.getItem("access_token"));
axiosInstanc.defaults.headers.common["Authorization"] = "Bearer " + localStorage.getItem("access_token");

export default axiosInstanc;