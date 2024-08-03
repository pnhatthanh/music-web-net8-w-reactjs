import actionTypes from "../actions/actionType";
import { getFirtSong } from "../store/musicStore";
const initState={
    curSongId: getFirtSong(),
    isPlaying: false
};
const musicReducer=(state=initState, action)=>{
    switch (action.type){
        case actionTypes.SET_CUR_SONG_ID:
            return {
                ...state,
                curSongId: action.songId || null
            };
        case actionTypes.PLAY:
            return {
                ...state,
                isPlaying: action.flag
            }
        default:
            return state
    }
}

export {initState};
export default musicReducer;