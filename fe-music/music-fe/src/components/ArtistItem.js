import React from 'react'

import { useNavigate } from 'react-router-dom';
import { IoPlay } from "react-icons/io5";
import generateTitle from '../ultis/generateTitle';
export default function ArtistItem(props) {
  const navigate=useNavigate();
  const handleNavigation = () => {
    navigate(`/artists/${generateTitle(props.name)}/${props.id}`);
  };

  return (
    <div className={`${props.isSearch ? 'flex gap-3 py-1 px-2 hover:bg-teal-800 group' : 'p-3 hover:bg-teal-900'} w-full relative group  rounded-lg transition-all cursor-pointer `}
      onClick={handleNavigation}
    >
        <img className={`object-cover rounded-full ${props.isSearch ? 'h-[60px] w-[60px]' : 'w-full'}`} src={props.thumbnail} alt="Artist"/>
        <div className='mt-2'>
            <h3 className={`${props.isSearch ? 'font-medium text-base text-slate-800 group-hover:text-slate-300' :'text-xl font-semibold text-slate-200'}`}>{props.name}</h3>
            <p className='text-sm font-normal text-slate-400'>Artist</p>
        </div>
        <span className='absolute group-hover:opacity-100 group-hover:bottom-[25%] opacity-0 right-4 bottom-[10%] cursor-pointer rounded-full text-slate-200 bg-green-600 p-3 transition-all'>
            <IoPlay size={28}/>
        </span>
    </div>
  )
}
