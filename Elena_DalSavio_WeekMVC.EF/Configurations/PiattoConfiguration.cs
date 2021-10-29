using Elena_DalSavio_WeekMVC.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace Elena_DalSavio_WeekMVC.EF
{
    public class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Piatto> builder)
        {
            builder.ToTable("Piatto"); //specifico il nome della tabella
            builder.HasKey(p => p.PiattoId); //specifico la chiave primaria
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Descrizione).IsRequired();
            builder.Property(p => p.Tipologia).IsRequired();
            builder.Property(p => p.Prezzo).IsRequired();

            builder.HasOne(p=> p.menuPiatti).WithMany(m => m.piatti).HasForeignKey(p => p.MenuPiattiId);
            
            
        }
    }
}
