import axios from "../axios";

export const getAllAlbum = (page=null, pageSize=null)=>{
    const params={}
    if(page!==null&&pageSize!==null){
        params.page=page;
        params.pageSize=pageSize
    }
    return axios.get('/album/paged',{params:params})
}
export const getAlbumById = (id) =>{
    return axios.get(`/album/${id}`)
}
export const getSongFromAlbum= (idAlbum)=>{
    return axios.get(`/album/songs/${idAlbum}`)
}