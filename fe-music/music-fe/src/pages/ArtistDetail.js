import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import icons from "../ultis/icon";
import ListSongItem from "../components/ListSongItem";
import ArtistItem from "../components/ArtistItem";
import ArtistModal from "../components/ArtistModal";
import * as apis from '../apis'


const { IoPlay, SlUserFollow,RiUserFollowFill } = icons;

export default function ArtistDetail() {
  const [isModalOpen, setIsModalOpen]=useState(false)
  const [artist, setArtist]=useState({})
  const [songs, setSongs]=useState([])
  const [artists,setArtists]=useState([])
  const {id}=useParams()
  useEffect(()=>{
    const fetchData=async (artistId)=>{
      const artistResponse=await apis.getArtistById(artistId);
      const songsResponse=await apis.getAllSongOfArtist(1,6,artistId)
      const artistsResponse=await apis.getAllArtist();
      setArtist(artistResponse.data?.data)
      setSongs(songsResponse.data?.data)
      setArtists(artistsResponse.data?.data.filter(a => a.artistId !== artistId))
    }
    fetchData(id)
  },[id])

  const toggleModal=()=>{
    setIsModalOpen(!isModalOpen)
  }
  return (
    <div>
      <div className="flex px-4 py-5 relative rounded-b-lg h-[200px] items-end text-white bg-slate-500">
        <img className="h-[150px] rounded-full object-cover mr-8" src={artist.imagePath} alt="Artist"/>
        <div className="flex-col items-center">
          <div className=" flex justify-center items-center">
            <h3 className="text-4xl font-semibold">{artist.artistName}</h3>
            <div className="ml-4 cursor-pointer rounded-full bg-teal-600 p-2 transition-all">
              <IoPlay size={30} />
            </div>
          </div>
          <div className="mt-2 flex items-center">
            <p className="text-base text-slate-200 mr-4">{artist.followers?.toLocaleString()} followers</p>
            <div className="flex py-1 px-2 cursor-pointer items-center justify-between border rounded-md">
                <SlUserFollow size={18}/>
                <span className="ml-2">Follow</span>
            </div>
          </div>
        </div>
      </div>
      <div className="px-3 mt-3">
        <h3 className="text-2xl text-white font-medium mb-3">Featured songs</h3>
        <div className="grid grid-cols-2 gap-x-2 px-1">
        {
          songs.map(song=>(
            <ListSongItem
              key={song.songId}
              songId={song.songId}
              thumbnail={song.songImagePath}
              title={song.songName}
              duration={song.duration}
              artist={song.artist.artistName}
            />
          ))
        }
        </div>
      </div>
      <div className="px-3 text-right">
        <button className='mr-3 text-base text-slate-200 font-medium cursor-pointer underline-offset-2 underline'>Expand</button>
      </div>
      <div className="px-3 mt-3">
        <h3 className="text-2xl text-white font-medium mb-3">About</h3>
        <div className="flex gap-x-5">
          <img className="h-[300px] w-2/5 object-top rounded-md" src={artist.imagePath} alt="Artist"/>
          <div className="py-2">
            <p className="text-slate-300 line-clamp-[8]">{artist.about}</p>
            <button onClick={toggleModal} className="underline decoration-solid text-slate-100 hover:text-slate-300">Xem thêm</button>
            <p className="mt-8 text-slate-200 text-lg flex items-center gap-1"><RiUserFollowFill size={20}/>{artist.followers?.toLocaleString()} followers</p>
          </div>
        </div>
      </div>
      <div className="px-3 mt-8">
        <h3 className="text-2xl text-white font-medium mb-3">Recommend</h3>
        <div className="grid grid-cols-4 gap-x-3">
        {
          artists.map(artist=>(
            <ArtistItem
              key={artist.artistId}
              id={artist.artistId}
              thumbnail={artist.imagePath}
              name={artist.artistName}
            />))
        }
        </div>
      </div>
      <ArtistModal
        isOpen={isModalOpen}
        onRequestClose={toggleModal}
        artist={artist.artistName}
        thumbnail={artist.imagePath}
        about={artist.about}
      />
    </div>
  );
}
