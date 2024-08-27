import axios from "axios";
import { addToken, getAccessToken, getRefereshToken } from "./store/tokenStore";
import { redirect } from "react-router-dom";
const instance = axios.create({
    baseURL: "http://localhost:5292/api/v1"
})

// Add a request interceptor
instance.interceptors.request.use(function (config) {
    const accessToken=getAccessToken();
    if(accessToken){
      config.headers.Authorization = `Bearer ${accessToken}`;
    }
    return config;
  }, function (error) {
    return Promise.reject(error);
});

// Add a response interceptor
instance.interceptors.response.use(function (response) {
    return response;
  }, async function (error) {
    const originalRequest=error.config;
    if(error.response.status===401&& !originalRequest._retry){
      originalRequest._retry=true;
      try{
        const refreshToken = getRefereshToken()
        const response = await axios.post('/auth/referesh', { RefreshToken:refreshToken });
        const { AccessToken, RefreshToken } = response.data;
        addToken(AccessToken,RefreshToken);
        originalRequest.headers.Authorization = `Bearer ${AccessToken}`;
        return axios(originalRequest)
      }catch(error){
        redirect('/login');
      }
    }
    const errorResponse={}
    if (error.response) {
      errorResponse.headers=error.response.headers;
      errorResponse.status=error.response.status;
      errorResponse.errorMessage=error.response.data;
    } else if (error.request) {
      console.log(error.request);
    } else {
      console.log('Error', error.message);
    }
    return errorResponse;
  }
);

export default instance