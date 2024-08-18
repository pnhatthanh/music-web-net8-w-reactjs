export const addToken=(accessToken, refereshToken)=>{
    localStorage.setItem('accessToken',accessToken)
    localStorage.setItem('refereshToken', refereshToken)
}
export const getAccessToken=()=>{
    return localStorage.getItem('accessToken') || null
}
export const getRefereshToken=()=>{
    return localStorage.getItem('refereshToken')
}
export const removeToken=()=>{
    localStorage.removeItem('accessToken')
    localStorage.removeItem('refereshToken')
}
export const isAuthenticated=()=>{
    return localStorage.getItem('accessToken') ? true : false 
}