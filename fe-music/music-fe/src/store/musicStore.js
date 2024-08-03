const QUEUE_MUSIC="queue_music";
const getMusicQueue=()=>{
    const songs=window.localStorage.getItem(QUEUE_MUSIC);
    return songs ? JSON.parse(songs) : [] 
}
const addMusic=(idSong)=>{
    const songs=getMusicQueue();
    if(songs.length>10)
        songs.pop();
    songs.unshift(idSong);
    saveMusic(songs)
}
const getFirtSong=()=>{
    const songs=getMusicQueue();
    return songs.at(0) || null
}
const saveMusic=(songs)=>{
    window.localStorage.setItem(QUEUE_MUSIC,JSON.stringify(songs))
}

export {getMusicQueue}
export {getFirtSong}
export {addMusic}