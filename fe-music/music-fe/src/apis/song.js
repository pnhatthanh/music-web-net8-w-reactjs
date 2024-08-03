import axios from '../axios'

export const getAllSong = (page=1, pageSize=8) => {
    return axios.get('/song',{
        params: {page, pageSize}
    });
};
export const getSongById = (id)=>{
    return axios.get(`/song/${id}`)
}

export const getRecentlyPlay=(songIds)=>{
    return axios.post('/song/recently-play',{songIds})
}


