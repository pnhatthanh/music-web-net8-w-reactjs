import React from 'react'
import Carousel from '../components/Carousel'
import SongItem from '../components/SongItem'

export default function Home() {
  return (
    <div>
      <Carousel/>
      <h3 className='text-xl font-bold text-white pt-2'>Discover</h3>
      <div className='grid grid-cols-4 grid-rows-2'>
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
      <h3 className='text-xl font-bold text-white pt-2'>Recommended album</h3>
      <div>
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
      <h3 className='text-xl font-bold text-white pt-2'>Best of artists</h3>
      <div>

      </div>
    </div>
  )
}
