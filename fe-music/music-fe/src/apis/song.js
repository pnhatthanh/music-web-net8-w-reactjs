import axios from '../axios'

export const getAllSong = (page=null, pageSize=null) => {
    const params={}
    if(page!==null&&pageSize!==null){
        params.page=page;
        params.pageSize=pageSize
    }
    return axios.get('/song',{params: params});
};
export const getSongById = (id)=>{
    return axios.get(`/song/${id}`)
}

export const getRecentlyPlay=(songIds)=>{
    return axios.post('/song/recently-play',{songIds})
}


