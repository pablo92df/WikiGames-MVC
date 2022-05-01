﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WikiGames.Models.Entities;

namespace WikiGames.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //todos los campos datetime los mapea tipo date en la base de datos. Esto lo hace por defecto
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        public DbSet<Marca> Marcas { get; set; }
    }
}
