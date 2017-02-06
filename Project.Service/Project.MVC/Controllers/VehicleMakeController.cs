using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Service.DAL;
using Project.Service.Models;
using Project.Service.ViewModels;
using PagedList;
using PagedList.Mvc;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private VehicleService vehicleService = new VehicleService();


        public ActionResult Index(string sortOrder, string searchString, string searchBy, int? page)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            if (searchString == null)
            {
                return View(vehicleService.SortFilterPagingMake(sortOrder, "", "", page));
            }
            else
            {
                return View(vehicleService.SortFilterPagingMake(sortOrder, searchString, searchBy, page));
            }
        }
        //// GET: VehicleMake/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMakeVM = vehicleService.FindIdMake(id);
            if (vehicleMakeVM == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMakeVM);
        }
        //GET: VehicleMake
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv")] VehicleMakeViewModel vehicleMakeView)
        {
            vehicleMakeView.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                vehicleService.CreateVehicleMake(vehicleMakeView);
                return RedirectToAction("Index");
            }

            return View(vehicleMakeView);
        }
        //// GET: VehicleMake/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMakeVM = vehicleService.FindIdMake(id);
            if (vehicleMakeVM == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMakeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VehicleMakeViewModel vehicleMakeView)
        {
            if (ModelState.IsValid)
            {
                vehicleService.EditVehicleMake(vehicleMakeView);
                return RedirectToAction("Index");
            }
            return View(vehicleMakeView);
        }

        //// GET: VehicleMake/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMakeVM = vehicleService.FindIdMake(id);
            if (vehicleMakeVM == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMakeVM);
        }

        //// POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            vehicleService.DeleteVehicleMake(id);
            return RedirectToAction("Index");
        }
    
}
}
