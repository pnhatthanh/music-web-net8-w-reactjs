import React, { memo } from 'react'

 function SongItem(props) {
  return (
    <div className='flex items-center rounded-xl px-2 py-2 gap-3 h-full w-full'>
        <img className='h-[60px] w-[60px] object-cover rounded-lg' src={props.thumbnail} alt="Imgae Song"/>
        <div>
            <h3 className='font-medium text-base text-slate-300 '>{props.title}</h3>
            <span className='text-slate-400'>{props.artist}</span>
        </div>
    </div>
  )
}
export default memo(SongItem)
