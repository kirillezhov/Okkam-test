import axios from 'axios';

const axiosInstance = axios.create({
    baseURL: 'http://localhost:5206/api/',
    timeout: 10000,
});

export default axiosInstance;