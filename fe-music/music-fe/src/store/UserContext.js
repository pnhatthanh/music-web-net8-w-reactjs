import React, { createContext, useState }  from "react";
import * as apis from '../apis';
import { removeToken, addToken, isAuthenticated, getAccessToken, getRefereshToken } from "./tokenStore"

const UserContext=createContext()
const UserProvider=({children})=>{
    const [user, setUser]=useState(isAuthenticated() ? {auth: true} : {auth: false})
    const login=(token)=>{
        addToken(token.accessToken, token.refereshToken)
        setUser({auth: true})
    }
    const logout=async ()=>{
        const token={
            AccessToken: getAccessToken(),
            RefereshToken: getRefereshToken()
        }
        try{
            await apis.logout(token)
            removeToken();
            setUser({auth: false})
        }catch(error){
            console.log(error)
        }
        
    }
    return(
        <UserContext.Provider value={{user, login, logout}}>
            {children}
        </UserContext.Provider>
    )
}
export {UserContext, UserProvider}