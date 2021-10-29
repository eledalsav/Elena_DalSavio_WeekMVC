using Elena_DalSavio_WeekMVC.Core;
using Elena_DalSavio_WeekMVC.Core.Entities;
using Elena_DalSavio_WeekMVC.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.EF
{
   public class MasterContext:DbContext
    {
        public DbSet<Piatto> Piatti { get; set; }
        public DbSet<MenuPiatti> MenuPiatti { get; set; }
        public DbSet<Utente> Utenti { get; set; }


        public MasterContext()
        {

        }

        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=MenuRistorante; Trusted_Connection = True;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Piatto>(new PiattoConfiguration());
            modelBuilder.ApplyConfiguration<MenuPiatti>(new MenuPiattiConfiguration());
            modelBuilder.ApplyConfiguration<Utente>(new UtenteConfiguration());
        }


    }
}
