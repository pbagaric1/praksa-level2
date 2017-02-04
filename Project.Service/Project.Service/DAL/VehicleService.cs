using Project.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project.Service.Models;
using System.Data.Entity;

namespace Project.Service.DAL
{
    public class VehicleService
    {
        public VehicleContext db = new VehicleContext();
        //public VehicleMakeViewModel VMakeView = new VehicleMakeViewModel();

        public static VehicleService instance;

        public VehicleService() { }

        public static VehicleService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VehicleService();
                }
                return instance;
            }
        }

        public void CreateVehicleMake(VehicleMakeViewModel Vm)
        {
            db.VehicleMakes.Add(Mapper.Map<VehicleMake>(Vm));
            db.SaveChanges();
        }

        public VehicleMakeViewModel FindIdMake(Guid? id)
        {
            VehicleMake vMake = db.VehicleMakes.Find(id);
            return Mapper.Map<VehicleMakeViewModel>(vMake);
        }

        public void EditVehicleMake(VehicleMakeViewModel Vm)
        {
            //db.VehicleMakes.Attach(Mapper.Map<VehicleMake>(Vm));
            db.Entry(Mapper.Map<VehicleMake>(Vm)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteVehicleMake(Guid id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            db.VehicleMakes.Remove(vehicleMake);
            db.SaveChanges();
        }

        public List<VehicleMakeViewModel> GetAllVehicleMakes()
        {

            return Mapper.Map<List<VehicleMakeViewModel>>(db.VehicleMakes.ToList());
        }

        public void CreateVehicleModel(VehicleModelViewModel Vm)
        {
            db.VehicleModels.Add(Mapper.Map<VehicleModel>(Vm));
            db.SaveChanges();
        }

        public VehicleModelViewModel FindIdModel(Guid? id)
        {
            VehicleModel vModel = db.VehicleModels.Find(id);
            return Mapper.Map<VehicleModelViewModel>(vModel);
        }

        public void EditVehicleModel(VehicleModelViewModel Vm)
        {
            //db.VehicleMakes.Attach(Mapper.Map<VehicleMake>(Vm));
            db.Entry(Mapper.Map<VehicleModel>(Vm)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteVehicleModel(Guid id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            db.VehicleModels.Remove(vehicleModel);
            db.SaveChanges();
        }

        public List<VehicleModelViewModel> GetAllVehicleModels()
        {

            return Mapper.Map<List<VehicleModelViewModel>>(db.VehicleModels.ToList());
        }
    }
}
