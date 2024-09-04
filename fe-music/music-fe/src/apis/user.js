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
export const register=(username, password, retypePassword)=>{
    const data={
        UserName: username,
        Password: password,
        ConfirmPassword: retypePassword
    }
    return axios.post('/user/register',data)
}
export const addSongToFavourite=(idSong)=>{
    return axios.put(`/user/favourite/add/song/${idSong}`);
}
export const getFavouriteSongs=(page, pageSize)=>{
    const params={
        page: page,
        pageSize: pageSize
    }
    return axios.get('/user/favourite/songs',{params: params});
}
export const removeFavouriteSong=(idSong)=>{
    return axios.put(`/user/favourite/remove/song/${idSong}`)
}