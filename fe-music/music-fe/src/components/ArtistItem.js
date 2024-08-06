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
    <div className='w-full relative p-3  rounded-lg transition-all cursor-pointer hover:bg-teal-900'
      onClick={handleNavigation}
    >
        <img className='w-full object-cover rounded-full' src={props.thumbnail} alt="Artist"/>
        <div className='px-1 mt-2'>
            <h3 className='text-xl font-semibold text-slate-200'>{props.name}</h3>
            <p className='text-sm font-normal text-slate-400'>Artist</p>
        </div>
        <span className='absolute right-4 bottom-4 cursor-pointer rounded-full text-slate-200 bg-teal-600 p-2 transition-all opacity-0'>
            <IoPlay size={22}/>
        </span>
    </div>
  )
}
