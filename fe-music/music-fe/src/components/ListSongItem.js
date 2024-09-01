import React from "react";
import { useEffect, useState, useRef } from 'react';
import moment from 'moment'
import { setCurSongId } from '../actions/musicAction'
import { useDispatch } from 'react-redux'
import { FaHeart, FaRegHeart  } from "react-icons/fa";
import { IoEllipsisHorizontalSharp, IoCaretForwardOutline } from "react-icons/io5";
//import { toast } from 'react-toastify';
import { FiTrash } from "react-icons/fi";
import { IoIosAddCircleOutline } from "react-icons/io";
import * as apis from '../apis'


export default function ListSongItem(props) {
  const dispatch=useDispatch();
  const [isPopupVisible, setPopupVisible] = useState(false);
  const dropdownRef = useRef(null);
  const handelClickSongItem = (songId)=>{
    dispatch(setCurSongId(songId))
  }
  const handlePopupDiffer = (e) => {
    e.stopPropagation();
    setPopupVisible(prev=>!prev);
  };

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
        event.stopPropagation();
        setPopupVisible(false);
      }
    };
    document.addEventListener('mousedown', handleClickOutside);
    return () => {
      document.removeEventListener('mousedown', handleClickOutside);
    };
  }, []);
  const handleSaveLikedSong=async (idSong)=>{
    await apis.addSongToFavourite(idSong);
  }
  return (
    <div className="flex justify-between items-center text-base py-2 border-b-[1px] border-b-slate-500 text-slate-100 mb-1 rounded-sm transition-all hover:bg-teal-900 cursor-pointer"
      onClick={()=>handelClickSongItem(props.songId)}>
      <div className="h-[45px] w-1/2 flex justify-between items-center rounded-xl px-2 ">
          <div className=" flex items-center rounded-xl px-2 gap-3">
            <img className="h-[45px] w-[45px] object-cover rounded-lg" src={props.thumbnail} alt="Imgae Song"/>
            <div>
              <h3 className="font-medium text-base text-slate-300 ">{props.title}</h3>
              <span className="text-slate-400">{props.artist}</span>
            </div>
          </div>
           {props.isFavourite && <FaHeart color="#EE2C2C" size={18}/>} 
      </div>
      {
        props.listenCount && <span className='w-1/4 flex items-center justify-center'>{props.listenCount?.toLocaleString('en-US')}</span>
      }
      <div className="w-1/4 flex justify-end gap-[20%] items-center">
        <span className="flex justify-center text-sm items-center">{moment.utc(props.duration*1000).format('mm:ss')}</span>
        <span className="relative flex  justify-center text-sm items-center px-1 py-1 z-10" title="More options" onClick={(e)=>handlePopupDiffer(e)}>
          <IoEllipsisHorizontalSharp size={20}/>
          {isPopupVisible && (
          <div ref={dropdownRef} className="absolute right-0 top-full w-max rounded-sm bg-slate-100 z-100 text-slate-900 text-sm px-1 py-1 flex flex-col gap-1">
            {props.isFavourite && 
              (
                <>
                  <button className='flex justify-between items-center gap-1 px-1 py-1 hover:bg-white'>
                    <div className="flex justify-start items-center gap-1 hover:bg-white"><IoIosAddCircleOutline size={18}/> Add to playlist </div>
                    <IoCaretForwardOutline size={18}/>
                  </button>
                  <button className='flex justify-start items-center gap-1 px-1 py-1 hover:bg-white'
                    onClick={props.onDelete}
                  ><FiTrash size={18}/> Remove from your favourite songs</button>                  
                </>
              )
            }
            {props.isPlaylist && (
              <>
                <button className='flex justify-between items-center gap-1 px-1 py-1 hover:bg-white'>
                  <div className="flex justify-start items-center gap-1 hover:bg-white"><IoIosAddCircleOutline size={18}/> Add to playlist </div>
                  <IoCaretForwardOutline size={18}/>
                </button>
                <button className='flex justify-start items-center gap-1 px-1 py-1 hover:bg-white'
                  onClick={()=>handleSaveLikedSong(props.songId)}
                ><FaRegHeart size={18}/> Save to your liked songs</button> 
              </>
            )}
            {props.isMyPlaylist && (
              <>
                <button className='flex justify-start items-center gap-1 px-1 py-1 hover:bg-white'><FiTrash size={18}/> Remove from this playlist</button> 
                <button className='flex justify-start items-center gap-1 px-1 py-1 hover:bg-white'
                  onClick={()=>handleSaveLikedSong(props.songId)}
                ><FaRegHeart size={18}/> Save to your liked songs</button> 
              </>
            )}
          </div>
          )}
        </span>
      </div>
      </div>
  );
}
