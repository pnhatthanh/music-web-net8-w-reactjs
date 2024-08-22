import React, { useState } from "react";
import { Link, useNavigate} from "react-router-dom";
import { toast } from "react-toastify";
import * as apis from '../apis';
export default function Register() {
    const [username, setUsername]=useState('');
    const [password, setPassword]=useState('');
    const [retypePassword, setRetypePassword]=useState('');
    const navigate=useNavigate()
    const handleSumbmit= async ()=>{
      if(!username || !password || !retypePassword){
        !username && toast.error("Email address is required!");
        !password && toast.error("Password is required!");
        !retypePassword && toast.error("Retype-password is required!")
        return;
      }
      if(password!==retypePassword){
        toast.error("Password dose not match")
        return;
      }
      const response=await apis.register(username,password,retypePassword);
      if(response.status!==200){
        toast.error(response.errorMessage)
      }else{
        toast.success("Registration successfully")
        navigate('/login')
      }
    }
  return (
    <section className="h-screen flex justify-center items-center bg-teal-900">
      <div className="flex w-2/5 h-auto gap-3 rounded-md overflow-hidden justify-center items-stretch  border-2">
      <div className=" max-w-sm py-4 px-3">
      <h2 className="text-center text-slate-200 text-2xl mb-2 font-semiboldbold">Register a new account </h2>
        <input className="text-sm w-full px-4 py-2 border border-solid border-gray-500 rounded" type="email"
          placeholder="Email Address"
          value={username}
          onChange={(e)=>setUsername(e.target.value)}
        />
        <input className="text-sm w-full px-4 py-2 border border-solid border-gray-500 rounded mt-4" type="password"
          placeholder="Password"
          value={password}
          onChange={(e)=>setPassword(e.target.value)}
        />
        <input className="text-sm w-full px-4 py-2 border border-solid border-gray-500 rounded mt-4" type="password"
          placeholder="Retype-password"
          value={retypePassword}
          onChange={(e)=>setRetypePassword(e.target.value)}
        />
        <div className="text-center md:text-left">
          <button
            className="mt-4 font-medium bg-green-700 hover:bg-green-600 px-4 py-2 text-white uppercase rounded text-xs w-full tracking-wider"
            type="submit"
            onClick={handleSumbmit}
          >
            Register
          </button>
        </div>
        <div className="my-3 flex items-center before:mt-0.5 before:flex-1 before:border-t before:border-neutral-300 after:mt-0.5 after:flex-1 after:border-t after:border-neutral-300">
          <p className="mx-4 mb-0 text-center font-semibold text-slate-500">
            Or
          </p>
        </div>
        
        <div className="text-center">
          {/* <!-- Facebook --> */}
            <button className="mb-3 flex w-full items-center justify-center rounded px-7 py-2 text-center text-sm font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#3b71ca] transition duration-150 ease-in-out hover:shadow-[0_8px_9px_-4px_rgba(84,180,211,0.3),0_4px_18px_0_rgba(84,180,211,0.2)] " style={{ backgroundColor: "#3b5998" }}
            >
              <svg xmlns="http://www.w3.org/2000/svg" className="mr-2 h-3.5 w-3.5" fill="currentColor" viewBox="0 0 24 24">
                <path d="M9 8h-3v4h3v12h5v-12h3.642l.358-4h-4v-1.667c0-.955.192-1.333 1.115-1.333h2.885v-5h-3.808c-3.596 0-5.192 1.583-5.192 4.615v3.385z" />
              </svg>
              Continue with Facebook
            </button>
          {/*<!--Google--!>*/}
            <button className="mb-3 flex w-full items-center justify-center rounded px-7 py-2 text-center text-sm font-medium uppercase leading-normal text-slate-800 shadow-[0_4px_9px_-4px_#54b4d3] transition duration-150 ease-in-out hover:shadow-[0_8px_9px_-4px_rgba(84,180,211,0.3),0_4px_18px_0_rgba(84,180,211,0.2)] " style={{ backgroundColor: "#F5F5F5" }}>
              <svg xmlns="http://www.w3.org/2000/svg" className="mr-2 h-3.5 w-3.5" viewBox="0 0 48 48">
                <path fill="#FFC107" d="M43.611,20.083H42V20H24v8h11.303c-1.649,4.657-6.08,8-11.303,8c-6.627,0-12-5.373-12-12c0-6.627,5.373-12,12-12c3.059,0,5.842,1.154,7.961,3.039l5.657-5.657C34.046,6.053,29.268,4,24,4C12.955,4,4,12.955,4,24c0,11.045,8.955,20,20,20c11.045,0,20-8.955,20-20C44,22.659,43.862,21.35,43.611,20.083z"></path><path fill="#FF3D00" d="M6.306,14.691l6.571,4.819C14.655,15.108,18.961,12,24,12c3.059,0,5.842,1.154,7.961,3.039l5.657-5.657C34.046,6.053,29.268,4,24,4C16.318,4,9.656,8.337,6.306,14.691z"></path><path fill="#4CAF50" d="M24,44c5.166,0,9.86-1.977,13.409-5.192l-6.19-5.238C29.211,35.091,26.715,36,24,36c-5.202,0-9.619-3.317-11.283-7.946l-6.522,5.025C9.505,39.556,16.227,44,24,44z"></path><path fill="#1976D2" d="M43.611,20.083H42V20H24v8h11.303c-0.792,2.237-2.231,4.166-4.087,5.571c0.001-0.001,0.002-0.001,0.003-0.002l6.19,5.238C36.971,39.205,44,34,44,24C44,22.659,43.862,21.35,43.611,20.083z"></path>
              </svg>
              Continue with Google
            </button>
        </div>
        <div className="text-center">
          <p className="text-slate-300 text-base">Do you have a account? <Link to={'/login'} className="hover:text-slate-200 underline underline-offset-2">Login now</Link> </p>
        </div>
      </div>
      </div>

    </section>
  )
}
