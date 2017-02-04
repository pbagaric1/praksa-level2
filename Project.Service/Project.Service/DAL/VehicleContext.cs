using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.DAL
{
    public class VehicleContext : DbContext
    {
        private static VehicleContext Instance;
        public VehicleContext() : base("VehicleContext")
        {
        }

        public static VehicleContext GetInstance()
        {
            if (Instance == null)
                Instance = new VehicleContext();
            return Instance;
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}