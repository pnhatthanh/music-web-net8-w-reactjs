import axios from "axios";
const instance = axios.create({
    baseURL: "http://localhost:5292/api/v1"
})
// Add a request interceptor
instance.interceptors.request.use(function (config) {
    return config;
  }, function (error) {
    return Promise.reject(error);
});

// Add a response interceptor
instance.interceptors.response.use(function (response) {
    return response;
  }, function (error) {
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