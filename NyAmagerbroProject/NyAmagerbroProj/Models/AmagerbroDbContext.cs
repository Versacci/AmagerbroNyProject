using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NyAmagerbroProj.Models
{
    public class AmagerbroDbContext : ApplicationDbContext
    {
        public AmagerbroDbContext()
        {
        }

        public DbSet<AmagerbroClothesStore> AmagerbroClothesStore { get; set; }
        public DbSet<AmagerbroElectronicsStore> AmagerbroElectronicsStore { get; set; }
        public DbSet<AmagerbroFoodStore> AmagerbroFoodStore { get; set; }
    }
}