import React from 'react'
import { IoPlay } from "react-icons/io5";

export default function AlbumItem(props) {
  return (
    <div className='w-full relative p-3 h-[300px] rounded-lg transition-all cursor-pointer hover:bg-teal-900'>
        <img className='w-full h-[220px] object-cover rounded-lg' src={props.thumbnail} alt='AlbumImage'/>
        <div className='px-1 mt-2'>
            <h3 className='text-xl font-semibold text-slate-200'>{props.title}</h3>
            <p className='text-sm font-normal text-slate-400'>{props.artists}</p>
        </div>
        <span className='absolute right-4 bottom-4 cursor-pointer rounded-full text-slate-200 bg-teal-600 p-2 transition-all opacity-0'>
            <IoPlay size={22}/>
        </span>
    </div>
  )
}
