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
    public class LocationController : Controller
    {
        private ILocationBL _locationBL;

        public LocationController(ILocationBL lBL)
        {
            this._locationBL = lBL;
        }
        // GET: LocationController
        public ActionResult Index()
        {
            return View(_locationBL.GetAllLocations().Select(loc => new LocationVM(loc)).ToList());
        }

        // GET: LocationController/Details/5
        public ActionResult Details(int id)
        {
            return View
                (
                _locationBL.GetAllLocations()
                .Select(location => new LocationVM(location))
                .ToList()
                );
        }

        // GET: LocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationVM locationVM)
        {
            try
            {
                var a = locationVM.Id;
                var b = locationVM.Name;
                var c = locationVM.City;
                var d = locationVM.State;

                if (ModelState.IsValid)
                {
                    _locationBL.AddLocation(new Location
                    {
                        LocationId = locationVM.Id,
                        Name = locationVM.Name,
                        City = locationVM.City,
                        State = locationVM.State
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

        // GET: LocationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationVM locationVM)
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

        // GET: LocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LocationVM locationVM)
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
