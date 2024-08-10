import React from 'react'
import Scrollbars from 'react-custom-scrollbars-2'
import { IoSearch } from "react-icons/io5";
import SongItem from '../components/SongItem'
import ArtistItem from '../components/ArtistItem'

export default function Search() {

  return (
    <div className='w-[45%] h-full bg-slate-50 flex border-2  rounded-full relative'>
      <div className='flex items-center bg-transparent px-2  text-slate-500 '>
        <IoSearch size={24}/>
      </div>
      <input className='w-full outline-none bg-transparent'  placeholder='What do you want to play?'/>
      <div className='absolute left-0 right-0 top-full hidden mt-2 w-full bg-slate-50 z-10 rounded-md px-1 py-1'>
      <Scrollbars style={{ width: '100%', height: '100%'}} autoHeight autoHeightMax={300}>
      <h4 className='px-1 font-medium text-base text-slate-600'>Songs</h4>
        <div className='mt-1'>
        <SongItem
            //key={song.songId}
            //songId={song.songId}
            isSearch={true}
            thumbnail="https://i.ytimg.com/vi/Kx4dmjbOaSU/sddefault.jpg"
            title="Giá như"
            artist="Soobin Hoang Son"
          />
        </div>
        <h4 className='px-1 font-medium text-base text-slate-600'>Artists</h4>
        <div className='mt-1'>
          <ArtistItem
            //key={artist.artistId}
            //id={artist.artistId}
            isSearch={true}
            thumbnail="https://vnn-imgs-f.vgcloud.vn/2019/02/22/09/img-3722.jpg"
            name="Soobin Hoang Son"
          />
        </div>
      </Scrollbars>
      </div>
    </div>
    
  )
}
