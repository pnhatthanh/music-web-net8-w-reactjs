import React from 'react'
import icons from '../ultis/icon'

const { FaHeart, GiNextButton, FaPlay, IoPlaySkipBack, IoMdPause, LiaRandomSolid, FaVolumeHigh, IoRepeat }=icons

export default function Player() {
  return (
    <div className='flex h-full bg-teal-900 '>
        <div className='mx-6 h-full w-[25%] flex-auto flex gap-4 items-center text-white '>
           <img className='w-[60px] h-[60px] object-cover rounded-lg' 
             src='https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg' alt="Image song"/>
            <div>
                <h3 className='font-medium text-base'>Shape of you</h3>
                <span className='text-slate-400'>Sheeran</span>
            </div>
            <FaHeart size={18}/>
        </div>
        <div className='w-[50%] h-full flex-auto flex flex-col justify-center gap-2'>
            <div className='flex justify-center gap-2 text-slate-300'>
                <span>00:00</span>
                <input
                        type="range"
                        className='w-[70%] '
                        defaultValue='0'
                />
                <span>00:00</span>
            </div>
            <div className='flex justify-center items-center gap-10 text-white'>
                <IoRepeat size={30}/>
                <IoPlaySkipBack size={30}/>
                <IoMdPause size={30}/>
                <GiNextButton size={30}/>
                <LiaRandomSolid size={30}/>
            </div>
        </div>
        <div className='w-[25%] flex-auto text-white h-full flex items-center justify-center gap-2'>
            <FaVolumeHigh size={24}/>
            <input
                        type="range"
                        className='w-[40%]'
                        defaultValue='0'
                />
        </div>
    </div>
  )
}
