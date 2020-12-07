import API from '../api';

export const callApi=async()=>{
    debugger;
    const response=await API.get("/api/secret");
    return response.data;
}