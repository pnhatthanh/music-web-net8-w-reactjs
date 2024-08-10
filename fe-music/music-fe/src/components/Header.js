import React from 'react'
import { IoNotifications } from "react-icons/io5";
import { IoChevronBack } from "react-icons/io5";
import { IoChevronForwardSharp } from "react-icons/io5";
import Search from './Search';
import { useNavigate, useParams } from 'react-router-dom';

export default function Header() {
  const history=useNavigate();
  const {artist}=useParams();
  console.log(history.length)
  const handleGoback=() => history(-1)
  const handleGoforward=() => history(+1)
  return (
    <div className={`${artist ? "bg-slate-500 rounded-t-2xl" : ""} h-[70px] flex px-3 py-[14px] justify-between items-center`}>
        <div className='flex text-slate-800 gap-2'>
            <span className={` p-1 rounded-full cursor-pointer bg-teal-700`} title='Go back' onClick={handleGoback}><IoChevronBack size={24}/></span>
            <span className='p-1 rounded-full cursor-pointer  bg-teal-700' title='Go Forward' onClick={handleGoforward}><IoChevronForwardSharp size={24}/></span>
        </div>
        <Search />
        <div className='flex text-amber-100 gap-3 items-center'>
            <IoNotifications size={24}/>
            <div className='w-10 h-10 rounded-full overflow-hidden'>
              <img className='w-full h-full object-cover' src='https://gcs.tripi.vn/public-tripi/tripi-feed/img/474088uQO/hinh-anh-nhung-con-cho-de-thuong_092948873.jpg' alt='User' />
            </div>
        </div>
    </div>
  )
}
