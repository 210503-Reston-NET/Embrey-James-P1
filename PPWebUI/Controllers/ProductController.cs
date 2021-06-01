using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPDL;
using PPBL;
using PPWebUI.Models;
using PPModels;

namespace PPWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductBL _productBL;

        public ProductController(IProductBL pBL)
        {
            _productBL = pBL;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productBL.GetAllProducts().Select(prod => new ProductVM(prod)).ToList());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View
                (
                _productBL.GetAllProducts()
                .Select(product => new ProductVM(product))
                .ToList()
                );
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM productVM)
        {
            try
            {
                var a = productVM.Id;
                var b = productVM.name;
                var c = productVM.quantity;
                var d = productVM.price;

                if (ModelState.IsValid)
                {
                    _productBL.AddProducts(new Products
                    {
                        ProductId = productVM.Id,
                        ProductName = productVM.name,
                        ProductQuantity = productVM.quantity,
                        ProductPrice = productVM.price
                    });
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        /*public ActionResult Edit(int id)
        {
            *//*var prd = _productBL.GetAllProducts(prod => prod.ProductId == Id).FirstOrDefault();*/
            /*return View(new ProductVM(_productBL.UpdateProduct(id)));*//*
        }*/

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductVM productVM)
        {
            try
            {
                var a = productVM.Id;
                var b = productVM.name;
                var c = productVM.quantity;
                var d = productVM.price;

                /*_productBL.UpdateProduct(new Products(productVM.Id, productVM.name, productVM.quantity, productVM.price));*/
                    return RedirectToAction(nameof(Index));     
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductVM productVM)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
