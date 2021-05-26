using System; 
using System.Collections.Generic; 
using PPDL;
using PPModels;
using Entity = PPDL.Entities;

namespace PPBL
{
    public class ProductBL : IProductBL
    {
        private IRepository _repo;

    public ProductBL(IRepository repo)
    {
        _repo = repo;
    }


    // public Products AddProduct(Products products)
    // {
    //     if(_repo.GetProducts(products)!=null)
    //     {
    //         throw new Exception ("Product already exists!");
    //     }
    //     return _repo.AddProduct(products);
    // }

    public List<Products> GetAllProducts()
    {
        return _repo.GetAllProducts();
    }

    // public Products DeleteProducts (Products products)
    // {
    //     if(_repo.DeleteProduct(products))
    //     {
            
    //     }
    // }

    }
}

