using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedSocial.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedSocial.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=RedSocial;Integrated Security=True;");
        }

        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Carrera> carreras { get; set; }
        public DbSet<RedSocial.Models.Amigos> Amigos { get; set; }
    }
}
