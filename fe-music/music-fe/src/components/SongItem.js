import React, { memo } from 'react'

 function SongItem(props) {
  return (
    <div className='flex rounded-xl px-2 py-2 gap-3'>
        <img className='w-[60px] h-[60px] object-cover rounded-lg' src={props.thumbnail} alt="Imgae Song"/>
        <div>
            <h3 className='font-medium text-base text-slate-300 '>{props.title}</h3>
            <span className='text-slate-400'>{props.artist}</span>
        </div>
    </div>
  )
}
export default memo(SongItem)
