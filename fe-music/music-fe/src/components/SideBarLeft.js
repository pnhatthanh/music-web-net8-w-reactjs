import React from 'react'
import logo from '../assets/logo.png'
import { NavLink, useNavigate } from 'react-router-dom'
import { sidebarMenu } from '../ultis/menu'
import { IoIosSettings } from "react-icons/io";

export default function SideBarLeft() {
  const navigate=useNavigate();
  const nonActiveStyle='flex py-2 px-[15px] mx-3 items-center gap-4 my-3 hover:text-white font-medium text-slate-300'
  const activeStyle='flex py-2 px-[15px] mx-3 items-center gap-4 my-3 rounded-xl font-bold text-white bg-teal-800'
  const navigateToHome=()=>{
    navigate('/');
  }
  return (
    <div className='h-full box-border flex flex-col  ml-1 bg-teal-900 py-5 rounded-2xl'>
      <div className='w-full h-[70px] pb-[10px] px-[25px] flex justify-start items-center mb-5 '>
          <img onClick={navigateToHome} src={logo} alt="logo" className='h-[60px] object-cover cursor-pointer'/>
      </div>
      <div>
        {sidebarMenu.map(item=>(
          <NavLink 
            to={item.path}
            key={item.path}
            className={({ isActive }) => `${isActive ? activeStyle : nonActiveStyle} transition-all`}
          >
            {item.icon}
            <span className='text-lg '>{item.text}</span>
          </NavLink>
        ))}
          <NavLink className={`${nonActiveStyle} border-t pt-4`}>
            <IoIosSettings size={24}/>
            <span className='text-lg '>Setting</span>
          </NavLink>
      </div>    
    </div>
  )
}
