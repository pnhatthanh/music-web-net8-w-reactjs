import React from 'react'
import Carousel from '../components/Carousel'
import SongItem from '../components/SongItem'
import AlbumItem from '../components/AlbumItem'
import ArtistItem from '../components/ArtistItem'
import { Link } from 'react-router-dom'

export default function Home() {
  return (
    <div className='px-2'>
      <Carousel/>
      <h3 className='text-xl font-bold text-white pt-2'>Discover</h3>
      <div className='grid grid-cols-4 grid-rows-2 mt-1 mb-4'>
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
      </div>
      <div className='flex justify-between items-end'>
          <h3 className='text-xl font-bold text-white pt-2'>Recommended album</h3>
          <Link to='/album' className='mr-3 text-base text-slate-200 font-medium  hover:underline'>Show all</Link>
      </div>
      <div className='grid grid-cols-4 grid-rows-1 gap-x-3 mt-1 mb-4'>
         <AlbumItem 
            thumbnail="https://bazaarvietnam.vn/wp-content/uploads/2023/03/Album-moi-cua-MCK.jpg"
            title="99%"
            artists="RPT MCK"
          />
          <AlbumItem 
            thumbnail="https://bazaarvietnam.vn/wp-content/uploads/2023/03/Album-moi-cua-MCK.jpg"
            title="99%"
            artists="RPT MCK"
          />
          <AlbumItem 
            thumbnail="https://bazaarvietnam.vn/wp-content/uploads/2023/03/Album-moi-cua-MCK.jpg"
            title="99%"
            artists="RPT MCK"
          />
          <AlbumItem 
            thumbnail="https://bazaarvietnam.vn/wp-content/uploads/2023/03/Album-moi-cua-MCK.jpg"
            title="99%"
            artists="RPT MCK"
          />
      </div>
      <div className='flex justify-between items-end'>
        <h3 className='text-xl font-bold text-white pt-2'>Best of artists</h3>
        <Link to='/artists' className='mr-3 text-base text-slate-200 font-medium  hover:underline'>Show all</Link>
      </div>
      <div className='grid grid-cols-4 grid-rows-1 gap-x-4 mt-1 mb-4'>
        <ArtistItem
          thumbnail="https://i1.sndcdn.com/artworks-i0nLuYBs0dR2nsn4-AkxVlg-t500x500.jpg"
            name="Son Tung MTP"
        />
        <ArtistItem
          thumbnail="https://i1.sndcdn.com/artworks-i0nLuYBs0dR2nsn4-AkxVlg-t500x500.jpg"
            name="Son Tung MTP"
        />
        <ArtistItem
          thumbnail="https://i1.sndcdn.com/artworks-i0nLuYBs0dR2nsn4-AkxVlg-t500x500.jpg"
            name="Son Tung MTP"
        />
        <ArtistItem
          thumbnail="https://i1.sndcdn.com/artworks-i0nLuYBs0dR2nsn4-AkxVlg-t500x500.jpg"
            name="Son Tung MTP"
        />
      </div>
      <div className='flex justify-between items-end'>
        <h3 className='text-xl font-bold text-white pt-2'>My favourite</h3>
        <Link to='/my-favourite' className='mr-3 text-base text-slate-200 font-medium  hover:underline'>Show all</Link>
      </div>
      <div className='grid grid-cols-4 grid-rows-1 mt-1 mb-4'>
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
        <SongItem 
          thumbnail="https://i.pinimg.com/originals/9a/e1/2b/9ae12b78327ed72e5ca9c255d394c78c.jpg"
          title="Shape of you"
          artist="Sheeran"
        />
      </div>
    </div>
  )
}
