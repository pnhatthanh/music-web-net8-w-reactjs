import React, { useContext } from 'react'
import { IoNotifications, IoLogInOutline, IoChevronBack, IoChevronForwardSharp, IoLogOutOutline, IoPerson } from "react-icons/io5";
import { GrUpgrade } from "react-icons/gr";
import Search from './Search';
import { useNavigate, useParams } from 'react-router-dom';
import { UserContext } from '../store/UserContext';

export default function Header() {
  const {user, setNotAuth}= useContext(UserContext)
  const history=useNavigate();
  const {artist}=useParams();
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
            {
              user && user.auth ? (
                <>
                <IoNotifications size={24}/>
                <div className='relative group pb-1'>
                  <div className='w-10 h-10 rounded-full overflow-hidden relative cursor-pointer'>
                    <img className='w-full h-full object-cover' src='https://gcs.tripi.vn/public-tripi/tripi-feed/img/474088uQO/hinh-anh-nhung-con-cho-de-thuong_092948873.jpg' alt='User'/>
                  </div>
                  <div className='absolute  right-0 top-full invisible group-hover:visible rounded-sm bg-slate-100 w-[170px] z-10 text-slate-900 text-base px-1 py-1 flex flex-col gap-1'>
                    <button className='flex justify-start items-center gap-1 px-2 py-1 hover:bg-white'>My account <IoPerson size={18}/></button>
                    <button className='flex justify-start items-center gap-1 px-2 py-1 hover:bg-white'>Upgrade account <GrUpgrade size={18}/></button>
                    <button className='flex justify-start items-center gap-1  px-2 py-1 hover:bg-white'
                      onClick={()=>setNotAuth()}
                    >Logout <IoLogOutOutline size={18}/></button>
                  </div>
                </div>
                
                </>
              ) : (
                <button className='px-4 py-1 text-lg rounded-lg bg-teal-900 font-medium hover:bg-teal-800 flex items-center gap-1 justify-center'
                  onClick={()=>window.location.href='/login'}
                >
                  Login <IoLogInOutline size={20}/>
                  </button>
              )
            }
        </div>
    </div>
  )
}
