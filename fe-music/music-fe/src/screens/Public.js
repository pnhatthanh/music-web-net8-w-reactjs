import React from 'react'
import { Outlet } from 'react-router-dom'
import { SideBarLeft, SideBarRight, Player } from '../components'

export default function Public() {
  return (
    <div className='w-full h-screen flex flex-col	bg-teal-950 '> 
      <div className='flex-auto w-full h-full flex'>
          <div className='w-[270px] my-3 flex-none'>
             <SideBarLeft/>
          </div>
          <div className='flex-auto'> 
            <Outlet/>
          </div>
          <div className='w-[330px]  flex-none'>
            <SideBarRight/>
          </div>
      </div>
      <div className='h-[100px] flex-none'>
          <Player/>
      </div>
    </div>
  )
}
