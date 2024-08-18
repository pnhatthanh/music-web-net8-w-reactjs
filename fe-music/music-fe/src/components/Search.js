import React, { useEffect, useRef, useState } from 'react'
import Scrollbars from 'react-custom-scrollbars-2'
import { IoSearch } from "react-icons/io5";
import SongItem from '../components/SongItem'
import ArtistItem from '../components/ArtistItem'
import * as apis from '../apis'

export default function Search() {
  const [search,setSearch]=useState('');
  const [isFocus,setIsFocus]=useState(false);
  const contain=useRef()
  const [artists,setArtists]=useState([])
  const [songs,setSongs]=useState([])
  useEffect(()=>{
    const fetchData=async (title)=>{
      if(title===''){
        setArtists([])
        setSongs([])
        return
      }
      const response=await apis.getSongOrArtistByTitle(title)
      setArtists(response.data?.data.artists)
      setSongs(response.data?.data.songs)
    }
    const debounceFetch=setTimeout(()=>{
      fetchData(search)
    },300)
    return ()=>{
      clearTimeout(debounceFetch)
    }
  },[search])
  const handleFocus=()=>setIsFocus(true)
  const handleBlur=(e)=>{
    setTimeout(() => {
      if (contain.current && !contain.current.contains(e.relatedTarget)) {
        setIsFocus(false);
      }
    }, 100);
  }
  return (
    <div className='w-[45%] h-full bg-slate-50 flex border-2  rounded-full relative'>
      <div className='flex items-center bg-transparent px-2  text-slate-500 '>
        <IoSearch size={24}/>
      </div>
      <input className='w-full outline-none bg-transparent' 
            value={search}
            onFocus={handleFocus}
            onBlur={(e)=>handleBlur(e)}
            onChange={(e)=>setSearch(e.target.value)}
            placeholder='What do you want to play?'/>
      <div ref={contain} className={`${isFocus ? '' : 'hidden'} absolute left-0 right-0 top-full mt-2 w-full bg-slate-50 z-10 rounded-md px-1`}>
      <Scrollbars style={{ width: '100%', height: '100%'}} autoHeight autoHeightMax={300}>
      {
        songs.length>0 && (
        <div className='py-1'>
          <h4 className='px-1 font-medium text-base text-slate-600'>Songs</h4>
          <div className='mt-1'>
            {
              songs.map(song=>(
                <SongItem
                  key={song.songId}
                  songId={song.songId}
                  isSearch={true}
                  thumbnail={song.songImagePath}
                  title={song.songName}
                  artist={song.artist.artistName}
                />
              ))
            }
          </div>
        </div>
        )
      }
      {
        artists.length>0&&(
          <div className='py-1'>
          <h4 className='px-1 font-medium text-base text-slate-600'>Artists</h4>
          <div className='mt-1'>
            {
              artists.map(artist=>(
                <ArtistItem
                  key={artist.artistId}
                  id={artist.artistId}
                  isSearch={true}
                  thumbnail={artist.imagePath}
                  name={artist.artistName}
                />
              ))
            }
        </div>
          </div>
        )
      }
      </Scrollbars>
      </div>
    </div>
    
  )
}
