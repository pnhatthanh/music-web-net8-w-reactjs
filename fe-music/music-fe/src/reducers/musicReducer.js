import actionTypes from "../actions/actionType";
import { getFirtSong, getSongRecent } from "../store/musicStore";
const initState={
    curSongId: getFirtSong(),
    isPlaying: false,
    recentSongs: getSongRecent()
};
const musicReducer=(state=initState, action)=>{
    switch (action.type){
        case actionTypes.SET_CUR_SONG_ID:
            return {
                ...state,
                isPlaying: true,
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
        default:
            return state
    }
}

export {initState};
export default musicReducer;