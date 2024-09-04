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
    const [page, setPage]=useState(1)
    const [totalSong, setToltalSong]=useState(0)
    const {favouriteSongs, curSongId}=useSelector(state=>state.musicReducer)
    const dispatch=useDispatch();
    const fetchData= async (data, page, pageSize)=>{
      const songResponse=await apis.getFavouriteSongs(page,pageSize);
      setToltalSong(songResponse.data?.toltalItem)
      setSongs([...data ,...songResponse.data?.data]);
    }
    useEffect(()=>{
      fetchData([],0, page * 5);
    },[favouriteSongs])

    const handleExpand=()=>{
      setPage(prev=>{
        fetchData(songs ,prev+1, 5);
        return prev+1
      })
    }
    const handleCollapse=()=>{
      setPage(prev=>{
        setSongs(prevSongs=>prevSongs.slice(0,(prev-1)*5))
        return prev-1
      })
    }
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
    <div>
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
    <div className={`${ page>1 ? 'flex justify-between' : 'text-right'} `}>
     { page>1 && songs.length>5 && <button className='ml-3 text-base text-slate-200 font-medium cursor-pointer underline-offset-2 underline' onClick={handleCollapse}>Collapse</button>}
     { totalSong > songs.length && <button className='mr-3 text-base text-slate-200 font-medium cursor-pointer underline-offset-2 underline' onClick={handleExpand}>Expand</button>}
    </div>
    <div className="mt-3">
      <h2 className="text-2xl font-bold text-white pt-2">Following</h2>
    </div>
    </div>
  );
}
