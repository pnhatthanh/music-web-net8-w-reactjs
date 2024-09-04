import React, { useEffect, useState } from 'react'
import SongItem from './SongItem';
import { useSelector } from 'react-redux';
import Scrollbars from 'react-custom-scrollbars-2';

export default function SideBarRight() {
  const [recent, setRecent] =useState(true);
  const [queuePlay, setQueuePlay]=useState([])
  const {recentSongs, queueSong} = useSelector(state=>state.musicReducer)
  const [recentPlays, setRecentPlays]= useState([])
  useEffect(()=>{
    setRecentPlays(recentSongs)
  },[recentSongs])
  useEffect(()=>{
    setQueuePlay(queueSong)
  })

  return (
    <div className='flex flex-col mr-1 h-full bg-teal-900 rounded-2xl' >
    <div className='h-[70px] mx-4 flex-none py-[14px] flex flex-row justify-center items-center gap-2 text-slate-300 font-medium'>
        <div className={`text-center px-3 py-2 transition-all  cursor-pointer ${ recent && 'text-white border-b-2'}`}
            onClick={()=>setRecent(prev=>!prev)}><span>Queue</span></div>
        <div className={` text-center px-3 py-2 transition-all  cursor-pointer ${ !recent && 'text-white border-b-2'}`}
             onClick={()=>setRecent(prev=>!prev)}><span>Recently played</span></div>
      </div>
    <Scrollbars>
      <div className='flex flex-col w-full ml-1 mr-1'>
      {
        recent ? (
          queuePlay.map(song=>{
            <SongItem
                key={song.songId}
                songId={song.songId}
                thumbnail={song.songImagePath}
                title={song.songName}
                artist={song.artistName}
            />
          })
        )
        : (
            recentPlays.map(song=>(
              <SongItem
                key={song.songId}
                songId={song.songId}
                thumbnail={song.songImagePath}
                title={song.songName}
                artist={song.artistName}
              />
            ))
          )
        }
      </div>
      </Scrollbars>
    </div>
  )
}
