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
    public class VehicleModelController : Controller
    {
        private VehicleService vehicleService;

        public VehicleModelController()
        {
            vehicleService = VehicleService.Instance();
        }

        // GET: VehicleModel
        public ActionResult Index(string sortOrder, string searchString, string searchBy, int? page)
        {
            ViewBag.NameSortParmMake = string.IsNullOrEmpty(sortOrder) ? "make_desc" : "";
            ViewBag.NameSortParmModel = sortOrder == "Model" ? "model_desc" : "Model";
            ViewBag.AbrvSortParmModel = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            if (searchString == null)
            {
                return View(vehicleService.SortFilterPagingModel(sortOrder, "", "", page));
            }
            else
            {
                return View(vehicleService.SortFilterPagingModel(sortOrder, searchString, searchBy, page));
            }
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelViewModel vehicleModelVM = vehicleService.FindIdModel(id);
            if (vehicleModelVM == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModelVM);
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {
            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetAllVehicleMakes(), "Id", "Name");
            return View();
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleModelId,VehicleMakeId,Name,Abrv")] VehicleModelViewModel vehicleModelView)
        {
            if (ModelState.IsValid)
            {
                vehicleModelView.VehicleModelId = Guid.NewGuid();
                vehicleService.CreateVehicleModel(vehicleModelView);
                return RedirectToAction("Index");
            }

            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetAllVehicleMakes(), "Id", "Name", vehicleModelView.VehicleMakeId);
            return View(vehicleModelView);
        }

        // GET: VehicleModel/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelViewModel vehicleModelVM = vehicleService.FindIdModel(id);
            if (vehicleModelVM == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetAllVehicleMakes(), "Id", "Name", vehicleModelVM.VehicleMakeId);
            return View(vehicleModelVM);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleModelId,VehicleMakeId,Name,Abrv")] VehicleModelViewModel vehicleModelVM)
        {
            if (ModelState.IsValid)
            {
                vehicleService.EditVehicleModel(vehicleModelVM);
                return RedirectToAction("Index");
            }
            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetAllVehicleMakes(), "Id", "Name", vehicleModelVM.VehicleMakeId);
            return View(vehicleModelVM);
        }

        // GET: VehicleModel/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelViewModel vehicleModelVM = vehicleService.FindIdModel(id);
            if (vehicleModelVM == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModelVM);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            vehicleService.DeleteVehicleModel(id);
            return RedirectToAction("Index");
        }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
    }
}
