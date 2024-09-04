import React, { useContext, useEffect, useState } from 'react'
import Carousel from '../components/Carousel'
import SongItem from '../components/SongItem'
import AlbumItem from '../components/AlbumItem'
import ArtistItem from '../components/ArtistItem'
import { Link } from 'react-router-dom'
import * as apis from '../apis'
import { UserContext } from '../store/UserContext'
export default function Home() {

  const {user}=useContext(UserContext);
  const [songs,setSongs]=useState([])
  const [albums,setAlbums]=useState([])
  const [artists,setArtists]=useState([])
  const [favouriteSongs, setFavouriteSongs]=useState([])
  useEffect(() => {
    const fetchData = async () => {
      try {
        const songResponse = await apis.getAllSong(1,8);
        const albumResponse= await apis.getAllAlbum(1,4);
        const artistResponse=await apis.getAllArtist(1,4);
        setSongs(songResponse.data?.data);
        setAlbums(albumResponse.data?.data); 
        setArtists(artistResponse.data?.data)
        if(user && user.auth){
          const favouriteResponse=await apis.getFavouriteSongs(1,4);
          setFavouriteSongs(favouriteResponse.data?.data)
        } 
      } catch (error) {
        console.error('Error fetching songs:', error);
      }
    };
    fetchData();
  }, []);
  
  return (
    <div className='px-3'>
      <Carousel/>
      <h3 className='text-xl font-bold text-white pt-2'>Discover</h3>
      <div className='grid grid-cols-4 grid-rows-2 mt-1 mb-4'>
      {
        songs.map(song=>(
          <SongItem
            key={song.songId}
            songId={song.songId}
            thumbnail={song.songImagePath}
            title={song.songName}
            artist={song.artist.artistName}
          />
        ))
      }
      </div>
      <div className='flex justify-between items-end'>
          <h3 className='text-xl font-bold text-white pt-2'>Recommended album</h3>
          <Link to='/albums' className='mr-3 text-base text-slate-200 font-medium  hover:underline'>Show all</Link>
      </div>
      <div className='grid grid-cols-4 grid-rows-1 gap-x-3 mt-1 mb-4'>
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
      <div className='flex justify-between items-end'>
        <h3 className='text-xl font-bold text-white pt-2'>Best of artists</h3>
        <Link to='/artists' className='mr-3 text-base text-slate-200 font-medium  hover:underline'>Show all</Link>
      </div>
      <div className='grid grid-cols-4 grid-rows-1 gap-x-4 mt-1 mb-4'>
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
      <div className='flex justify-between items-end'>
        <h3 className='text-xl font-bold text-white pt-2'>My favourite</h3>
        <Link to='/my-favourite' className='mr-3 text-base text-slate-200 font-medium  hover:underline'>Show all</Link>
      </div>
      
      {
        user && user.auth ? (
          <div className='grid grid-cols-4 grid-rows-1 mt-1 mb-4'>
            {favouriteSongs.map(song=>(
              <SongItem
                key={song.songId}
                songId={song.songId}
                thumbnail={song.songImagePath}
                title={song.songName}
                artist={song.artist.artistName}
              />
              ))
            }
          </div>
        ):(
          <p className='text-center text-base text-slate-400 mt-5 pb-4 font-medium'>Sign in for a better experience.&nbsp;
             <button className='hover:text-slate-200 underline underline-offset-2'
              onClick={()=>window.location.href='/login'}
              >Sign in</button></p>
        )
      }
    </div>
  )
}
