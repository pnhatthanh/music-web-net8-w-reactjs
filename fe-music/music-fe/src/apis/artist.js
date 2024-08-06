import axios from "../axios";

export const getAllArtist=(page=1, pageSize=4)=>{
    return axios.get('/artist/paged',{
        params: {page, pageSize}
    })
}
export const getArtistById=(id)=>{
    return axios.get(`/artist/${id}`)
}

export const getAllSongOfArtist=(page=1, pageSize=6, id)=>{
    return axios.get(`/artist/${id}/songs/paged`,{
        params: {page,pageSize}
    })
}