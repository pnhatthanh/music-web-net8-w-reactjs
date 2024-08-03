import React, { useEffect, useRef, useState } from 'react'
import moment from 'moment'
import { useSelector } from 'react-redux'
import icons from '../ultis/icon'
import * as apis from '../apis'
import { addMusic } from '../store/musicStore'


const { FaHeart, IoPlaySkipForward, IoPlay, IoPlaySkipBack, IoMdPause, LiaRandomSolid, FaVolumeHigh, IoRepeat }=icons

export default function Player() {
    const songId=useSelector(state=>state.musicReducer.curSongId)
    const audio=useRef(new Audio())
    const song=useRef(null);
    const [statePause,settPlay]=useState(true)
    const [duration, setDuration]=useState(1)
    const [currentTime, setCurrentTime]=useState(0);
    useEffect(()=>{
        const fetchSong=async(id)=>{
            if(id==null){
                audio.current.src="https://cdn.pixabay.com/audio/2022/11/11/audio_84306ee149.mp3" 
            }else{
                const response=await apis.getSongById(id);
                addMusic(id);
                song.current=response.data?.data
                audio.current.src=song.current.songPath; 
            }
            audio.current.load();
            const updateTime = () => setCurrentTime(audio.current.currentTime);
            const updateDuration = () =>  setDuration(audio.current.duration)
            audio.current.addEventListener('timeupdate', updateTime);
            audio.current.addEventListener('loadedmetadata', updateDuration)
            return () => {
                audio.current.removeEventListener('timeupdate', updateTime)
                audio.current.removeEventListener('loadedmetadata',updateDuration)
            }
        }
        fetchSong(songId);
    },[songId]);

    const handelPlay = ()=>
        settPlay(prev=>{
            prev === true ? audio.current.play() :  audio.current.pause();
            return !prev;
        })
  return (
    <div className='flex h-full bg-teal-900 '>
        <div className='mx-6 h-full w-[25%] flex-auto flex gap-4 items-center text-white '>
           <img className='w-[60px] h-[60px] object-cover rounded-lg' 
             src={song.current ? song.current.songImagePath : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQH0xOElRH5j5yp3mrk5Ru5Q44-j06i5-ShrQ&s"} alt="Thumbnail song"/>
            <div>
                <h3 className='font-medium text-base'>{song.current ? song.current.songName : "Music life"}</h3>
                <span className='text-slate-400'>{song.current ? song.current.artist.artistName : "PNT"}</span>
            </div>
            <FaHeart size={18}/>
        </div>
        <div className='w-[50%] h-full flex-auto flex flex-col justify-center gap-2'>
            <div className='flex justify-center items-center gap-2 text-slate-300'>
                <span>{moment.utc(currentTime*1000).format('mm:ss')}</span>
                <input
                        type="range"
                        className='w-[70%] cursor-pointer h-1'
                        min={0}
                        step={0.00001}
                        max={duration}
                        value={currentTime}
                        onChange={e=>audio.current.currentTime=e.target.value}
                />
                <span>{moment.utc(duration*1000).format('mm:ss')}</span>
            </div>
            <div className='flex justify-center items-center gap-10 text-white'>
                <span className='cursor-pointer'><IoRepeat size={30}/></span>
                <span className='cursor-pointer'><IoPlaySkipBack size={30}/></span>
                <span onClick={handelPlay} className='cursor-pointer rounded-full bg-slate-400 p-2 transition-all'> 
                    {statePause ? <IoPlay size={30}/> : <IoMdPause size={30}/>}
                </span>
                <span className='cursor-pointer'><IoPlaySkipForward size={30}/></span>
                <span className='cursor-pointer'><LiaRandomSolid size={30}/></span>
            </div>
        </div>
        <div className='w-[25%] flex-auto text-white h-full flex items-center justify-center gap-2'>
            <FaVolumeHigh size={24}/>
            <input
                        type="range"
                        className='w-[40%] h-1 cursor-pointer'
                        defaultValue={0.5}
                        min={0}
                        max={1}
                        step={0.1}
                        onChange={e=>audio.current.volume=e.target.value}
                />
        </div>
    </div>
  )
}
