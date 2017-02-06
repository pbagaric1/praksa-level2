using PagedList;
using Project.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.DAL
{
    interface IVehicleService
    {
        void CreateVehicleMake(VehicleMakeViewModel Vm);
        VehicleMakeViewModel FindIdMake(Guid? id);
        void EditVehicleMake(VehicleMakeViewModel Vm);
        void DeleteVehicleMake(Guid id);
        List<VehicleMakeViewModel> GetAllVehicleMakes();
        void CreateVehicleModel(VehicleModelViewModel Vm);
        VehicleModelViewModel FindIdModel(Guid? id);
        void EditVehicleModel(VehicleModelViewModel Vm);
        void DeleteVehicleModel(Guid id);
        List<VehicleModelViewModel> GetAllVehicleModels();
        IPagedList<VehicleMakeViewModel> SortFilterPagingMake(string sortOrder, string searchString, string searchBy, int? page);
        IPagedList<VehicleModelViewModel> SortFilterPagingModel(string sortOrder, string searchString, string searchBy, int? page);
    }
}
