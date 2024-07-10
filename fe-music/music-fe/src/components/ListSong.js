import React from 'react'
import { IoTimeOutline } from "react-icons/io5";
import { FaHeadphones } from "react-icons/fa6";

import SongItem from './SongItem';

export default function ListSong() {
  return (
    <div className='px-2'>
        <div className='flex justify-between gap-2 text-lg text-slate-100'>
            <span className='w-1/2'>#Name of the song</span>
            <span className='w-1/3 flex items-center gap-2'><FaHeadphones size={18}/>Plays</span>
            <span className='w-1/5 flex items-center gap-2'><IoTimeOutline size={18}/>Duration</span>
        </div>
        <div className='py-2'>
            <div className='flex justify-between gap-2 text-base text-slate-100 my-1 rounded-xl transition-all hover:bg-teal-900 cursor-pointer'>
                <div className='h-[60px] w-1/2'>
                    <SongItem 
                        thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
                        title="Shape of you"
                        artist="Sheeran"
                    />
                </div>
                <span className='w-1/3 flex items-center'>1,346,889</span>
                <span className='w-1/5 flex justify-center items-center'>04:56</span>
            </div>
            <div className='flex justify-between gap-2 text-base text-slate-100 my-1 rounded-xl transition-all hover:bg-teal-900 cursor-pointer'>
                <div className='h-[60px] w-1/2'>
                    <SongItem 
                        thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
                        title="Shape of you"
                        artist="Sheeran"
                    />
                </div>
                <span className='w-1/3 flex items-center'>1,346,889</span>
                <span className='w-1/5 flex justify-center items-center'>04:56</span>
            </div>
            <div className='flex justify-between gap-2 text-base text-slate-100 my-1 rounded-xl transition-all hover:bg-teal-900 cursor-pointer'>
                <div className='h-[60px] w-1/2'>
                    <SongItem 
                        thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
                        title="Shape of you"
                        artist="Sheeran"
                    />
                </div>
                <span className='w-1/3 flex items-center'>1,346,889</span>
                <span className='w-1/5 flex justify-center items-center'>04:56</span>
            </div>
            <div className='flex justify-between gap-2 text-base text-slate-100 my-1 rounded-xl transition-all hover:bg-teal-900 cursor-pointer'>
                <div className='h-[60px] w-1/2'>
                    <SongItem 
                        thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
                        title="Shape of you"
                        artist="Sheeran"
                    />
                </div>
                <span className='w-1/3 flex items-center'>1,346,889</span>
                <span className='w-1/5 flex justify-center items-center'>04:56</span>
            </div>
            <div className='flex justify-between gap-2 text-base text-slate-100 my-1 rounded-xl transition-all hover:bg-teal-900 cursor-pointer'>
                <div className='h-[60px] w-1/2'>
                    <SongItem 
                        thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
                        title="Shape of you"
                        artist="Sheeran"
                    />
                </div>
                <span className='w-1/3 flex items-center'>1,346,889</span>
                <span className='w-1/5 flex justify-center items-center'>04:56</span>
            </div>
            <div className='flex justify-between gap-2 text-base text-slate-100 my-1 rounded-xl transition-all hover:bg-teal-900 cursor-pointer'>
                <div className='h-[60px] w-1/2'>
                    <SongItem 
                        thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
                        title="Shape of you"
                        artist="Sheeran"
                    />
                </div>
                <span className='w-1/3 flex items-center'>1,346,889</span>
                <span className='w-1/5 flex justify-center items-center'>04:56</span>
            </div>
            <div className='flex justify-between gap-2 text-base text-slate-100 my-1 rounded-xl transition-all hover:bg-teal-900 cursor-pointer'>
                <div className='h-[60px] w-1/2'>
                    <SongItem 
                        thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
                        title="Shape of you"
                        artist="Sheeran"
                    />
                </div>
                <span className='w-1/3 flex items-center'>1,346,889</span>
                <span className='w-1/5 flex justify-center items-center'>04:56</span>
            </div>
        </div>
    </div>
  )
}
