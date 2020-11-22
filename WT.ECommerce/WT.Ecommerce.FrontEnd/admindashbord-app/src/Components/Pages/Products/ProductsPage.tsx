import React,{useEffect,useState} from 'react'
import {withRouter ,useHistory, useParams, Link } from 'react-router-dom';
import {featchProducs} from '../../../utils/ProductApi'
import {Product,Links,ProductList,PageLink} from '../../../Types/Product'
import {Table,Pagination} from 'react-bootstrap'

type Props={
  
};

const ProductsPage:React.FC<Props>=({

})=>{

    const[products,setProducts]=useState<Product[]>([]);
    const[links,setLinks]=useState<Links>();

    const FetchPage=async(pageLink:PageLink)=>{
        
        let pageUrl:string|undefined=undefined;
        switch(pageLink){
          case PageLink.Next:
            pageUrl=links?.next;
            break;
          case PageLink.Prev:
                pageUrl=links?.prev;
                break;
          case PageLink.First:
                pageUrl=links?.first;
                break;
          case PageLink.Last:
                pageUrl=links?.last;
                break;
        }

         const result= await featchProducs(0,10,pageUrl);

          setProducts(result.results.slice());
          setLinks(result.links);

    }


    const startFeatchProducts=async()=>{
      
      const result= await featchProducs(0,10,undefined);
      setProducts(result.results.slice());
      setLinks(result.links);
    }
    
    useEffect(() => {
        startFeatchProducts();
    }, []);

    let page:any=null;
    page= page=(<div className="SearchDiv">
            <h4>Products</h4>
            <Table striped bordered hover responsive>
            <thead>
             <tr>
                 <th>#ProductId</th>
                 <th>name</th>
                 <th>description</th>
                 <th>value</th>
                 <th>categoryName</th>
             </tr>
            </thead>
            <tbody>
                {products.map(a=>{
                      return (<tr><td><a>{a.id}</a> </td><td>{a.name}</td><td>{a.description}</td><td>{a.value}</td><td>{a.categoryName}</td></tr>)
                     })}
               
            </tbody>
            </Table>
             <div className="pagination-centered">
              <Pagination size="lg">
                <Pagination.First  onClick={()=> FetchPage(PageLink.First)} />
                <Pagination.Prev disabled={links?.prev ==''} onClick={()=> FetchPage(PageLink.Prev)} />
                <Pagination.Next disabled={links?.next ==''} onClick={()=> FetchPage(PageLink.Next)} />
                <Pagination.Last   onClick={()=> FetchPage(PageLink.Last)} />
              </Pagination>
             </div>
           
          </div>)
    return (page)
}

export default ProductsPage;