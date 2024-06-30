import React from 'react'
import { MdSpaceDashboard, MdFavorite } from 'react-icons/md'
import { FaGripfire,FaPlay, FaSignOutAlt } from 'react-icons/fa'
import { IoLibrary } from 'react-icons/io5'
import SidebarButton from './sidebarButton'

import './sidebar.css'

export default function Sidebar() {
  return (
    <div className='sidebar-container'>
        <img src='https://gcs.tripi.vn/public-tripi/tripi-feed/img/474088uQO/hinh-anh-nhung-con-cho-de-thuong_092948873.jpg' 
            className='profile-image' alt='pmage'/>
        <div >
            <SidebarButton title="Feed" to="/feed" icon={<MdSpaceDashboard />}/>
            <SidebarButton title="Trending" to='/trending' icon={<FaGripfire />} />
            <SidebarButton title="Player" to='/player' icon={<FaPlay />}/>
            <SidebarButton title="Favourite" to='/favourite' icon={<MdFavorite />}/>
            <SidebarButton title="Library" to='/' icon={<IoLibrary />}/>
        </div>
       <SidebarButton title="Sign-out" to='/signout' icon={<FaSignOutAlt />}/>
    </div>
  )
}
