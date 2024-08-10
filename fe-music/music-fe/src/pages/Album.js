import React from 'react'
import { useState, useEffect } from 'react';
import AlbumItem from '../components/AlbumItem'
import * as apis from '../apis';

export default function Album() {
  const [albums, setAlbums]=useState([])
  useEffect(()=>{
    const fetchData=async ()=>{
      const response=await apis.getAllAlbum()
      setAlbums(response.data?.data)
    }
    fetchData();
  },[])
  return (
    <div className='px-3'>
      <h2 className='text-white font-bold text-3xl'>Albums</h2>
      <div className='grid grid-cols-4 gap-x-3 gap-y-4 mt-5 mb-4'>
      {
        albums.map(album=>(
          <AlbumItem
            key={album.albumId}
            id={album.albumId}
            thumbnail={album.imagePath}
            title={album.albumName}
          />
        ))
      }
      </div>
    </div>
  )
}
