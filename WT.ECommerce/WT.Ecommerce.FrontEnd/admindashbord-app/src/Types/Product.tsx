import { type } from "os";

export type Product={
    id:Number,
    name:string,
    description:string|null,
    value:number,
    categoryName:string
}

export type Links={
    self:string,
    first:string,
    prev:string,
    next:string,
    last:string,
    recordCount:number,
    pageCount:number
}

export type ProductList={
    results:Product[],
    links:Links
}

export enum PageLink
{
   Next,
   Prev,
   First,
   Last
}