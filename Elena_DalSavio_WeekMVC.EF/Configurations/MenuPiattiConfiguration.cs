using Elena_DalSavio_WeekMVC.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.EF
{
    public class MenuPiattiConfiguration : IEntityTypeConfiguration<MenuPiatti>
    {
        public void Configure(EntityTypeBuilder<MenuPiatti> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.MenuPiattiId);
            builder.Property(m => m.Nome).IsRequired();

            builder.HasMany(p => p.piatti).WithOne(m => m.menuPiatti).HasForeignKey(m => m.MenuPiattiId);
        }
    }
}
