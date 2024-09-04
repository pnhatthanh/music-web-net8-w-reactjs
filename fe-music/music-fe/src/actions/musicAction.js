import actionTypes from "./actionType";

export const setCurSongId=(songId)=>({
    type: actionTypes.SET_CUR_SONG_ID,
    songId
})

export const setPlay=(flag)=>({
    type: actionTypes.PLAY,
    flag
})
 export const setRecentSong=()=>({
    type: actionTypes.SET_RECENT_SONGS,
 })
 export const setQueueSong=()=>({
   type: actionTypes.SET_QUEUE_SONGS
 })
 export const setFavouriteSongs=()=>({
    type: actionTypes.SET_FAVOURITE_SONGS
 })
 export const setIsFavourite=(isFavourite)=>({
    type: actionTypes.SET_IS_FAVOURITE,
    isFavourite
 })