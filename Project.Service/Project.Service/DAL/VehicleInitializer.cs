using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project.Service.DAL
{
    public class VehicleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var makes = new List<VehicleMake>
            {
            new VehicleMake { Name= "VolksWagen", Abrv= "VW" },
            new VehicleMake { Name = "Bayerische Motoren Werke ", Abrv = "BMW" }
            };

            makes.ForEach(s => context.VehicleMakes.Add(s));
            context.SaveChanges();
            var models = new List<VehicleModel>
            {
            new VehicleModel { VehicleMakeId=Guid.NewGuid(), Name= "Golf", Abrv= "VW"},
            new VehicleModel { VehicleMakeId=Guid.NewGuid(), Name= "X6", Abrv= "BMW" }
            };
            models.ForEach(s => context.VehicleModels.Add(s));
            context.SaveChanges();
        }
    }
}
