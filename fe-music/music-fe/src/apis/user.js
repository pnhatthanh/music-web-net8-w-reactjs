import axios from "../axios";

export const login=(username, password)=>{
    const data={
        Email: username,
        Password: password
    }
    return axios.post('/auth/login',data)
}
export const logout=(token)=>{
    return axios.post('/auth/logout', token)
}