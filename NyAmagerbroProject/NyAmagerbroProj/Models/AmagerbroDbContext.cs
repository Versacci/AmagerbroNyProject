using NyAmagerbroProj.Models.AmagercentretStore;
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
        public DbSet<AmagercentretClothes> AmagerbrocentretClothes { get; set; }
        public DbSet<AmagercentretElectronics> AmagercentretElectronics { get; set; }
        public DbSet<AmagercentretFood> AmagercentretFood { get; set; }
    }
}