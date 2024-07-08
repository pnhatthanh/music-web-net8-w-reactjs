import actionTypes from "./actionType";

export const setCurSongId=(songId)=>({
    type: actionTypes.SET_CUR_SONG_ID,
    songId
})

export const setPlay=(flag)=>({
    type: actionTypes.PLAY,
    flag
})