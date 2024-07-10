import React from 'react'
import { IoSearch } from "react-icons/io5";
export default function Search() {

  return (
    <div className='w-[45%] h-full bg-slate-50 flex border-2  rounded-full overflow-hidden'>
      <div className='flex items-center bg-transparent px-2  text-slate-500 '>
        <IoSearch size={24}/>
      </div>
      <input className='w-full outline-none bg-transparent'  placeholder='What do you want to play?'/>
    </div>
    
  )
}
