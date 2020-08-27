using System;
using System.Collections.Generic;
using System.Text;
using TCBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace TCBlazor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Nacionalidades> Nacionalidades { get; set; }
        public DbSet<Adicionales> Adicionales { get; set; }
        public DbSet<Tareas> Tareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\TCBlazor.db");
        }
    }
}