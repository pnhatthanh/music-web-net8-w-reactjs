import React, { memo } from 'react'
import { setCurSongId } from '../actions/musicAction'
import { useDispatch } from 'react-redux'

 function SongItem(props) {
  const dispatch=useDispatch();
  const handelClickSongItem = (songId)=>{
    dispatch(setCurSongId(songId))
  }
  return (
    <div className={`flex items-center px-1 gap-3 h-full w-full cursor-pointer mb-1 hover:bg-teal-800 py-1 ${props.isSearch ? 'rounded-md py-1 group' : 'rounded-lg'}`}
        onClick={()=>handelClickSongItem(props.songId)}
        >
        <img className='h-[60px] w-[60px] object-cover rounded-lg' src={props.thumbnail} alt="Imgae Song"/>
        <div>
            <h3 className={`font-medium text-base ${props.isSearch ?'text-slate-800 group-hover:text-slate-300': 'text-slate-300'}`}>{props.title}</h3>
            <span className='text-slate-400'>{props.artist}</span>
        </div>
    </div>
  )
}
export default memo(SongItem)
