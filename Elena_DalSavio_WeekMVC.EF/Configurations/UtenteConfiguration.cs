using Elena_DalSavio_WeekMVC.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.EF.Configurations
{
    internal class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> modelBuilder)
        {
            modelBuilder.ToTable("Utente");
            modelBuilder.HasKey(s => s.Id);
            modelBuilder.Property(s => s.Nome).IsRequired();
            modelBuilder.Property(s => s.Username).IsRequired();
            modelBuilder.Property(s => s.Password).IsRequired();
            modelBuilder.Property(s => s.Ruolo).IsRequired();
        }
    }
}
