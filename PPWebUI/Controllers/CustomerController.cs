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
using Serilog;

namespace PPWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBL _customerBL;

        public CustomerController(ICustomerBL cBL)
        {
            this._customerBL = cBL;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_customerBL.GetAllCustomers().Select(custo => new CustomerVM(custo)).ToList());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View
                (
                _customerBL.GetAllCustomers()
                .Select(customer => new CustomerVM(customer))
                .ToList()
                );
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerVM customerVM)
        {
            try
            {
                var a = customerVM.Id;
                var b = customerVM.name;
                var c = customerVM.locale;

                Random nums = new Random();
                int ID = nums.Next(1111, 9999);

                if (ModelState.IsValid)
                {
                    _customerBL.AddCustomer(new Customer
                    {
                        CustomerId = ID,
                        Name = customerVM.name,
                        Locale = customerVM.locale,
                    }
                    );
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerVM customerVM)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _customerBL.AddCustomer(new Customer
                    {
                        CustomerId = customerVM.Id,
                        Name = customerVM.name,
                        Locale = customerVM.locale,
                    }
                    );
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CustomerVM customerVM)
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
