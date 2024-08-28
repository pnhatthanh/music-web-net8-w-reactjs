import React from "react";
import { useEffect, useRef, useState } from 'react';
import moment from 'moment'
import { setCurSongId } from '../actions/musicAction'
import { useDispatch } from 'react-redux'
import { FaHeart, FaRegHeart  } from "react-icons/fa";
import { IoEllipsisHorizontalSharp, IoCaretForwardOutline } from "react-icons/io5";
import { FiTrash } from "react-icons/fi";
import { IoIosAddCircleOutline } from "react-icons/io";


export default function ListSongItem(props) {
  const dispatch=useDispatch();
  const [isPopupVisible, setPopupVisible] = useState(false);
  const popupRef = useRef(null);
  const handelClickSongItem = (songId)=>{
    dispatch(setCurSongId(songId))
  }
  const handlePopupDiffer = (e) => {
    e.stopPropagation();
    setPopupVisible(!isPopupVisible);
  };
  useEffect(() => {
    const handleClickOutside = (event) => {
      if (popupRef.current && !popupRef.current.contains(event.target)) {
        setPopupVisible(false);
      }
    };
    document.addEventListener('click', handleClickOutside);
    return () => {
      document.removeEventListener('click', handleClickOutside);
    };
  }, [popupRef]);
  return (
    <div className="flex justify-between items-center text-base py-2 border-b-[1px] border-b-slate-500 text-slate-100 mb-1 rounded-sm transition-all hover:bg-teal-900 cursor-pointer"
      onClick={()=>handelClickSongItem(props.songId)}>
      <div className="h-[45px] w-2/5 flex justify-between items-center rounded-xl px-2 ">
          <div className="h-[45px] flex items-center rounded-xl px-2 gap-3">
            <img className="h-[45px] w-[45px] object-cover rounded-lg" src={props.thumbnail} alt="Imgae Song"/>
            <div>
              <h3 className="font-medium text-base text-slate-300 ">{props.title}</h3>
              <span className="text-slate-400">{props.artist}</span>
            </div>
          </div>
           {props.isFavourite && <FaHeart color="#EE2C2C" size={18}/>} 
      </div>
      <span className={`w-1/3 ${props.listenCount ? 'flex': 'hi'} items-center justify-center`}>{props.listenCount?.toLocaleString('en-US')}</span>
      <span className="w-1/5 flex justify-center text-sm items-center">{moment.utc(props.duration*1000).format('mm:ss')}</span>
      <span className="w-1/12 relative flex justify-center text-sm items-center py-1" title="Different" onClick={(e)=>handlePopupDiffer(e)}>
          <IoEllipsisHorizontalSharp size={20}/>
          {isPopupVisible && (
          <div className="absolute right-0 top-full w-max rounded-sm bg-slate-100 z-100 text-slate-900 text-sm px-1 py-1 flex flex-col gap-1">
            <button className='flex justify-between items-center gap-1 px-1 py-1 hover:bg-white'>
              <div className="flex justify-start items-center gap-1 hover:bg-white"><IoIosAddCircleOutline size={18}/> Add to playlist </div>
              <IoCaretForwardOutline size={18}/>
            </button>
            {props.isFavourite&& <button className='flex justify-start items-center gap-1 px-1 py-1 hover:bg-white'><FiTrash size={18}/> Remove from your favourite songs</button>}
            <button className='flex justify-start items-center gap-1 px-1 py-1 hover:bg-white'><FiTrash size={18}/> Remove from this playlist</button> 
            <button className='flex justify-start items-center gap-1 px-1 py-1 hover:bg-white'><FaRegHeart size={18}/> Save to your liked songs</button> 
          </div>
          )}
      </span>
    </div>
  );
}
