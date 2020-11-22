import {Product,Links,ProductList} from '../Types/Product'
import axios from 'axios'
import API from './api'
import { promises } from 'dns';

export const featchProducs=async(skip:number,limit:number,endPoint:string|undefined):Promise<ProductList>=>{

    const query=endPoint?endPoint:`Product?skip=${skip}&limit=${limit}`;

    const response=await API.get(query);
    
    return response.data


}