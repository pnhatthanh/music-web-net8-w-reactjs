import React from 'react'
import AlbumItem from '../components/AlbumItem'

export default function Album() {
  return (
    <div className='pr-2'>
      <h2 className='text-white font-bold text-3xl'>Albums</h2>
      <div className='grid grid-cols-4 gap-x-3 gap-y-4 mt-5 mb-4'>
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
    </div>
  )
}
