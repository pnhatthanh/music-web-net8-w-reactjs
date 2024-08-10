import React, { useEffect, useState } from 'react'
import ArtistItem from '../components/ArtistItem'
import * as apis from '../apis';
export default function Artist() {
  const [artists, setArtists]=useState([])
  useEffect(()=>{
    const fetchData=async ()=>{
      const response=await apis.getAllArtist();
      setArtists(response.data?.data)
    }
    fetchData();
  },[])
  return (
    <div className='px-3'>
      <h2 className='text-white font-bold text-3xl'>Artists</h2>
      <div className='grid grid-cols-4 gap-x-3 gap-y-4 mt-5 mb-4'>
      {
        artists.map(artist=>(
          <ArtistItem
            key={artist.artistId}
            id={artist.artistId}
            thumbnail={artist.imagePath}
            name={artist.artistName}
          />
        ))
      }
      </div>
    </div>
  )
}
