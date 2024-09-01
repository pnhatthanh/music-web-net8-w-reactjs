import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import { IoTimeOutline } from "react-icons/io5";
import { FaHeadphones } from "react-icons/fa6";
import * as apis from '../apis'
import ListSongItem from '../components/ListSongItem';

export default function AlbumDetail() {
    const {id}= useParams();
    const [album,setAlbum]=useState({})
    const [songs,setSongs]=useState([])
    useEffect(()=>{
      const fetchData=async (id)=>{
        const albumResponse=await apis.getAlbumById(id)
        const songResponse=await apis.getSongFromAlbum(id)
        setAlbum(albumResponse.data?.data)
        setSongs(songResponse.data?.data)
      }
      fetchData(id);
    },[id])
  return (
    <div className='flex gap-4 w-full items-start px-3'>
        <div className='flex-1 w-1/3 flex flex-col justify-center text-center text-slate-400'>
            <img className='w-full object-contain rounded-xl' src={album.imagePath} alt={album.albumName}/>
            <h3 className='text-slate-100 text-2xl font-semibold mt-2'>{album.albumName}</h3>
            <p className='text-sm'>{album.description}</p>
            <span className='text-sm'>{album.numberOfSong} songs</span>
        </div>
        <div className='flex-2 w-2/3 px-2'>
          <div className='flex justify-between gap-2 text-lg text-slate-100'>
            <span className='w-1/2'>#Name of the song</span>
            <span className='w-1/4 flex justify-center items-center gap-2'><FaHeadphones size={18}/>Plays</span>
            <span className='w-1/4 flex justify-center items-center gap-2'><IoTimeOutline size={18}/>Duration</span>
          </div>
          <div className='py-2'>
            {
              songs.map(song=>(
                <ListSongItem
                  key={song.songId}
                  songId={song.songId}
                  thumbnail={song.songImagePath}
                  title={song.songName}
                  duration={song.duration}
                  listenCount={song.listenCount}
                  artist={song.artist.artistName}
                  isPlaylist={true}
                />
              ))
            }
          </div>
        </div>
    </div>
  )
}
