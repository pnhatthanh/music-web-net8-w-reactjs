const SONG_RECENT="song_recent";
const QUEUE_SONG="queue_song";
const getSongRecent=()=>{
    const songs=window.localStorage.getItem(SONG_RECENT);
    return songs ? JSON.parse(songs) : [] 
}
const getQueueSong=()=>{
    const songs=window.localStorage.getItem(QUEUE_SONG)
    return songs ?  JSON.parse(songs) : []
}
const setQueueSong=(songs)=>{
    window.localStorage.setItem(QUEUE_SONG,JSON.stringify(songs))
}
const addMusic=(song)=>{
    const songs=getSongRecent();
    const index = songs.findIndex(s=>s.songId===song.songId)
    if(index===-1){
        if(songs.length>10)
            songs.pop();
        songs.unshift(song);
    }else{
        songs.unshift(...songs.splice(index, 1));
    }
    saveMusic(songs)
}
const getFirtSong=()=>{
    const songs=getSongRecent();
    return songs.at(0) || null
}
const saveMusic=(songs)=>{
    window.localStorage.setItem(SONG_RECENT,JSON.stringify(songs))
}

export {getSongRecent}
export {setQueueSong}
export {getQueueSong}
export {getFirtSong}
export {addMusic}