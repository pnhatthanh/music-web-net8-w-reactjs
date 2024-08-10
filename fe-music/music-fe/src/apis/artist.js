import axios from "../axios";

export const getAllArtist=(page=null, pageSize=null)=>{
    const params={}
    if(page!==null&&pageSize!==null){
        params.page=page;
        params.pageSize=pageSize
    }
    return axios.get('/artist/paged',{params:params})
}
export const getArtistById=(id)=>{
    return axios.get(`/artist/${id}`)
}

export const getAllSongOfArtist=(page=1, pageSize=6, id)=>{
    return axios.get(`/artist/${id}/songs/paged`,{
        params: {page,pageSize}
    })
}