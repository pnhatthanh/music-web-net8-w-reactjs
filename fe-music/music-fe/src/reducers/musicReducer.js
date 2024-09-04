import actionTypes from "../actions/actionType";
import { getFirtSong, getSongRecent, getQueueSong } from "../store/musicStore";
const initState={
    curSongId: getFirtSong()?.songId,
    isPlaying: false,
    recentSongs: getSongRecent(),
    queueSongs: getQueueSong(),
    isFavourite: true,
    favouriteSongs: false
};
const musicReducer=(state=initState, action)=>{
    switch (action.type){
        case actionTypes.SET_CUR_SONG_ID:
            return {
                ...state,
                isPlaying: true,
                isFavourite: true,
                curSongId: action.songId || null
            };
        case actionTypes.PLAY:
            return {
                ...state,
                isPlaying: action.flag
            }
        case actionTypes.SET_RECENT_SONGS:
            return {
                ...state,
                recentSongs: getSongRecent()
            }
        case actionTypes.SET_QUEUE_SONGS:
            return {
                ...state,
                queueSongs: getQueueSong()
            }
        case actionTypes.SET_FAVOURITE_SONGS:
            return {
                ...state,
                favouriteSongs: !state.favouriteSongs
            }
        case actionTypes.SET_IS_FAVOURITE:
            return {
                ...state,
                isFavourite: action.isFavourite
            }
        default:
            return state
    }
}

export {initState};
export default musicReducer;