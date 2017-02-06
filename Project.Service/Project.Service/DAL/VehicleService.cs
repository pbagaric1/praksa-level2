using Project.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project.Service.Models;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace Project.Service.DAL
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleContext db; 
        public static VehicleService instance;

        public VehicleService()
        {
            db = VehicleContext.Instance();
        }

        public static VehicleService Instance()
        {

                if (instance == null)
                {
                    instance = new VehicleService();
                }
                return instance;
         
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

        public IPagedList<VehicleMakeViewModel> SortFilterPagingMake(string sortOrder, string searchString, string searchBy, int? page)
        {
            switch (searchBy)
            {
                case "Name":
                 switch (sortOrder)
            {
                case "name_desc":
                    return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(s => s.Name.Contains(searchString)).OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                    return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(s => s.Name.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                    return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(s => s.Name.Contains(searchString)).OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                    return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(s => s.Name.Contains(searchString)).OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);

                    }

                case "Abrv":
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(s => s.Abrv.Contains(searchString)).OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(s => s.Abrv.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(s => s.Abrv.Contains(searchString)).OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(s => s.Abrv.Contains(searchString)).OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);

                    }
                default:
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);

                    }
            }

        }

        public IPagedList<VehicleModelViewModel> SortFilterPagingModel(string sortOrder, string searchString, string searchBy, int? page)
        {
            switch (searchBy)
            {
                case "Make":
                    switch (sortOrder)
                    {
                        case "make_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.VehicleMake.Name.Contains(searchString)).OrderByDescending(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, 3);
                        case "Model":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.VehicleMake.Name.Contains(searchString)).OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "model_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.VehicleMake.Name.Contains(searchString)).OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.VehicleMake.Name.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.VehicleMake.Name.Contains(searchString)).OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.VehicleMake.Name.Contains(searchString)).OrderBy(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, 3);

                    }

                case "Name":
                    switch (sortOrder)
                    {
                        case "make_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Name.Contains(searchString)).OrderByDescending(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, 3);
                        case "Model":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Name.Contains(searchString)).OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "model_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Name.Contains(searchString)).OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Name.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Name.Contains(searchString)).OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Name.Contains(searchString)).OrderBy(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, 3);

                    }

                case "Abrv":
                    switch (sortOrder)
                    {
                        case "make_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Abrv.Contains(searchString)).OrderByDescending(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, 3);
                        case "Model":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Abrv.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "model_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Abrv.Contains(searchString)).OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Abrv.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Abrv.Contains(searchString)).OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(s => s.Abrv.Contains(searchString)).OrderBy(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, 3);

                    }
                default:
                    switch (sortOrder)
                    {
                        case "make_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.OrderByDescending(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, 3);
                        case "Model":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "model_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.OrderBy(x => x.VehicleMake.Name)).ToPagedList(page ?? 1, 3);

                    }
            }
        }
        }
}
