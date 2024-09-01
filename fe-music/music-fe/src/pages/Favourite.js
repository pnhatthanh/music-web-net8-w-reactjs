import React, { useEffect, useState } from "react";
import { IoTimeOutline } from "react-icons/io5";
import { FaHeadphones } from "react-icons/fa6";
import ListSongItem from '../components/ListSongItem';
import { toast } from 'react-toastify';
import * as apis from '../apis'
import { useDispatch, useSelector } from "react-redux";
import { setFavouriteSongs, setIsFavourite} from "../actions/musicAction";
export default function Favourite() {
    const [songs,setSongs]=useState([])
    const {favouriteSongs, curSongId}=useSelector(state=>state.musicReducer)
    const dispatch=useDispatch();
    useEffect(()=>{
      const fetchData= async ()=>{
        const songResponse=await apis.getFavouriteSongs();
        setSongs(songResponse.data?.data);
      }
      fetchData();
    },[favouriteSongs])

    const removeFromFavourite = async (idSong) => {
      await apis.removeFavouriteSong(idSong)
      dispatch(setFavouriteSongs())
      idSong === curSongId && dispatch(setIsFavourite(false))
      toast.success("Delete successfully",{
        position: "bottom-center",
        autoClose: 800
      })
    };
  return (
    <div className="px-3">
      <h2 className="text-2xl font-bold text-white pt-2">My favourite songs</h2>
      <div className='w-full px-2 mt-3'>
          <div className='flex justify-between gap-2 text-lg text-slate-100'>
            <span className='w-1/2'>#Name of the song</span>
            <span className='w-1/4 flex items-center gap-2 justify-center'><FaHeadphones size={18}/>Plays</span>
            <span className='w-1/4 flex items-center gap-2 justify-center'><IoTimeOutline size={18}/>Duration</span>
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
                  isFavourite={true}
                  onDelete={()=>removeFromFavourite(song.songId)}
                />
              ))
            }
          </div>
        </div>
    </div>
  );
}
