import React from 'react'
import { FaPlayCircle } from "react-icons/fa";
import './library.css'
import { IconContext } from 'react-icons';

export default function Library() {
  return (
    <div className='screen-container'>
      <div className='library-screen'>
        <div className='playList-item'>
          <img src='https://mekoong.com/wp-content/uploads/2022/11/pexels-ron-lach-7792647-scaled.jpg' className='playList-img' alt="Image-playlist"/>
          <p className='playList-title'>Taylor Switch</p>
          <p className='playList-songs'>50 Songs</p>
          <div className='playList-fade'>
            <IconContext.Provider value={{size: "40px", color: "#E99072"}}>
              <FaPlayCircle />
            </IconContext.Provider>
          </div>
        </div>
      </div>
    </div>
  )
}
