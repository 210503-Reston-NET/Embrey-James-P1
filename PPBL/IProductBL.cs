using PPModels;
using System.Collections.Generic;

namespace PPBL
    {
      public interface IProductBL
        {
        Products AddProducts(Products products);

        /*Products UpdateProduct(Products products);*/

        List<Products> GetAllProducts();
        // Product DeleteProducts(Products products);

    }
    }