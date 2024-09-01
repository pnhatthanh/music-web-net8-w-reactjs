import React from 'react'
import { IoPlay } from "react-icons/io5";
import { useNavigate } from 'react-router-dom';
import generateTitle from '../ultis/generateTitle';

export default function AlbumItem(props) {
  const navigate=useNavigate();
  const handleNavigation = () => {
    navigate(`/albums/${generateTitle(props.title)}/${props.id}`);
  };
  return (
    <div className='group w-full relative p-3 h-[300px] rounded-lg transition-all cursor-pointer hover:bg-teal-900'
      onClick={handleNavigation}>
        <img className='w-full h-[220px] object-cover rounded-lg' src={props.thumbnail} alt='AlbumImage'/>
        <div className='px-1 mt-2'>
            <h3 className='text-xl font-semibold text-slate-200'>{props.title}</h3>
            <p className='text-sm font-normal text-slate-400'>{props.artists}</p>
        </div>
        <span className='absolute group-hover:opacity-100 group-hover:bottom-[25%] opacity-0 right-4 bottom-[10%] cursor-pointer rounded-full text-slate-200 shadow-2xl bg-green-600 p-3 transition-all  duration-300'>
            <IoPlay size={28}/>
        </span>
    </div>
  )
}
