import axios from "../axios";

export const getAllAlbum = (page=1, pageSize=4)=>{
    return axios.get('/album/paged',{
        params: {page, pageSize}
    })
}
export const getAlbumById = (id) =>{
    return axios.get(`/album/${id}`)
}
export const getSongFromAlbum= (idAlbum)=>{
    return axios.get(`/album/songs/${idAlbum}`)
}