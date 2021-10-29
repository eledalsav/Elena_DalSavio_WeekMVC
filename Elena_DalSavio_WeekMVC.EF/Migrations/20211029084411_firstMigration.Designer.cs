﻿// <auto-generated />
using Elena_DalSavio_WeekMVC.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Elena_DalSavio_WeekMVC.EF.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20211029084411_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Elena_DalSavio_WeekMVC.Core.MenuPiatti", b =>
                {
                    b.Property<string>("MenuPiattiId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuPiattiId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Elena_DalSavio_WeekMVC.Core.Piatto", b =>
                {
                    b.Property<string>("PiattoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuPiattiId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tipologia")
                        .HasColumnType("int");

                    b.HasKey("PiattoId");

                    b.HasIndex("MenuPiattiId");

                    b.ToTable("Piatto");
                });

            modelBuilder.Entity("Elena_DalSavio_WeekMVC.Core.Piatto", b =>
                {
                    b.HasOne("Elena_DalSavio_WeekMVC.Core.MenuPiatti", "menuPiatti")
                        .WithMany("piatti")
                        .HasForeignKey("MenuPiattiId");

                    b.Navigation("menuPiatti");
                });

            modelBuilder.Entity("Elena_DalSavio_WeekMVC.Core.MenuPiatti", b =>
                {
                    b.Navigation("piatti");
                });
#pragma warning restore 612, 618
        }
    }
}