import axios, { AxiosResponse } from "axios";
import { Product } from "../store/Product";


axios.defaults.baseURL = 'https://localhost:7048/api';

axios.interceptors.response.use(async (response) => {
    try {
        return response;
    } catch (error) {
        console.log(`Api error: ${error}`);
        alert(`Api error: ${error}`)
        return await Promise.reject(error);
    }
}, function (error) {
    // Any status codes that falls outside the range of 2xx cause this function to trigger   
    return Promise.reject(error);
})

const responseData = <T>(response: AxiosResponse<T>) => response.data;

const axiosRequests = {
    getAll: <T>(url: string) => axios.get<T>(url).then(responseData),
    create: <T>(url: string, productData: Product) => axios.post<T>(url, productData).then(responseData)
}

export const ProductsApi = {
    getAll: () => axiosRequests.getAll<Product[]>('/products'),
    create: (productData: Product) => axiosRequests.create<Product>('/products', productData)
}