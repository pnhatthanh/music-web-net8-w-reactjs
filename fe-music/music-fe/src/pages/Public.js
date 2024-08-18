import React from 'react'
import { Outlet } from 'react-router-dom'
import { SideBarLeft, SideBarRight, Player, Header } from '../components'
import Scrollbars from 'react-custom-scrollbars-2'

export default function Public() {
  return (
    <div className="w-full relative h-screen flex flex-col bg-teal-950">
  <div className="flex-auto w-full h-full flex">
    <div className="w-[270px] mt-2 overflow-hidden flex-none mb-[100px]">
      <SideBarLeft />
    </div>
    <div className="flex-auto mt-2 mb-[100px] mx-1 ">
      <Header />
      <Scrollbars style={{ width: '100%', height: 'calc(100% - 100px)'}}>
        <Outlet />
      </Scrollbars>
    </div>
    <div className="w-[300px] mt-2 flex-none mb-[90px]">
        <SideBarRight />
    </div>
  </div>
  <div className="fixed bottom-0 left-0 right-0 h-[100px]">
    <Player />
  </div>
</div>

  )
}
