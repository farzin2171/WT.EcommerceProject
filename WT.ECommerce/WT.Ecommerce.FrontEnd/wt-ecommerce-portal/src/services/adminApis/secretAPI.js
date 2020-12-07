import API from '../api';

export const callApi=async()=>{
    debugger;
    const response=await API.get("/api/secret");
    return response.data;
}

export const submitFile=async(file)=>{
    const response=await API.post("/api/public",file);
    return response.data;
}