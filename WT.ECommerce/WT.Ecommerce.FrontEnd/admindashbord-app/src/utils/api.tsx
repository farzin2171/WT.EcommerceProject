import axios from 'axios'
const {REACT_APP_ADMIN_API_BASEURL} = process.env

export default axios.create({
    baseURL:REACT_APP_ADMIN_API_BASEURL
})