using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using AppCuerdasVibrantes.Models.Entities;

namespace AppCuerdasVibrantes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public ApplicationDbContext()

        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

            optionBuilder.UseSqlServer("Server=localhost;" +
                   "Database=CuerdasVibrantes;" +
                   "Trusted_Connection=True;" +
                   "MultipleActiveResultSets=True");
        }

        public virtual DbSet<PIEZOMETROS> PIEZOMETROS { get; set; }

        public virtual DbSet<PIEZOMETROS_REPORTES_EXCEL> PIEZOMETROS_REPORTES_EXCEL { get; set; }

        public virtual DbSet<PIEZOMETROS_REPORTES_EXCEL_CONVERT> PIEZOMETROS_REPORTES_EXCEL_CONVERT { get; set; }

        public virtual DbSet<ARCHIVOS> ARCHIVOS { get; set; }

        public virtual DbSet<PIEZOMETROS_DETALLE> PIEZOMETROS_DETALLE { get; set; }


    }
}
