import React from 'react'
import { useParams } from 'react-router-dom'
import ListSong from '../components/ListSong';
export default function AlbumDetail() {
    const {title, id}= useParams();
    console.log(title+id);
  return (
    <div className='flex gap-4 w-full items-start'>
        <div className='flex-1 w-1/3 flex flex-col justify-center text-center text-slate-400'>
            <img className='w-full object-contain rounded-xl' src='https://smilemedia.vn/wp-content/uploads/2022/08/Concept-Thanh-Xuan-Hoi-Uc-Smile-Media.jpg'/>
            <h3 className='text-slate-100 text-2xl font-semibold leading-loose'>Thanh xuân</h3>
            <p className='text-sm'>Best of V-Pop thanh xuân</p>
            <span className='text-sm'>50 songs</span>
        </div>
        <div className=' flex-2 w-2/3'>
          <ListSong/>
        </div>
    </div>
  )
}
