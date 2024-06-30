import React from 'react'
import { Routes, Route} from 'react-router-dom'
import Feed from '../feed/feed'
import Favourite from '../favourite/favourite'
import Trending from '../trending/trending'
import Player from '../player/player'
import Library from '../library/library'
import './home.css'
import Sidebar from '../../components/sidebar'

export default function Home() {
  return (
    <div className='main-body'>
      <Sidebar/>
      <Routes>
            <Route path='/' element={<Library/>}/>
            <Route path='/feed' element={<Feed/>}/>
            <Route path='/trending' element={<Trending/>}/>
            <Route path='/player' element={<Player/>}/>
            <Route path='/favourite' element={<Favourite/>}/>
      </Routes>
    </div>
  )
}
