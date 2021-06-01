using System;
using System.Collections.Generic;
using PPDL;
using PPModels;


namespace PPBL
{
    public class ProductBL : IProductBL
    {
        private IRepository _repo;

        public ProductBL(IRepository repo)
        {
            _repo = repo;
        }


         public Products AddProducts(Products products)
         {
            if(_repo.GetProducts(products)!=null)
            {
                throw new Exception("Product already exists!");
                return new Products();

            }
            return _repo.AddProducts(products);

         }

        public List<Products> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        /*public Products DeleteProducts (Products products)
        {
            if(_repo.DeleteProduct(products))
            {

            }
        }*/

    }
}

