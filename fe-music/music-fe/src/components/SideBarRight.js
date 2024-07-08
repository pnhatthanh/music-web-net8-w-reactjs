import React, { useState } from 'react'
import SongItem from './SongItem';

export default function SideBarRight() {
  const [recent, setRecent] =useState(true);
  return (
    <div className='flex flex-col h-full bg-teal-900 overflow-y-auto rounded-2xl' >
      <div className='h-[70px] mx-4 flex-none py-[14px] flex flex-row justify-center items-center gap-2 text-slate-300 font-medium'>
        <div className={`text-center px-3 py-2 transition-all  cursor-pointer ${ recent && 'text-white border-b-2'}`}
            onClick={()=>setRecent(prev=>!prev)}><span>Queue</span></div>
        <div className={` text-center px-3 py-2 transition-all  cursor-pointer ${ !recent && 'text-white border-b-2'}`}
             onClick={()=>setRecent(prev=>!prev)} ><span>Recently played</span></div>
      </div>
      <div className='flex flex-col w-full'>
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
      </div>
    </div>
  )
}
