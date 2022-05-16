using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<JuegoConsola>().HasKey(prop => new { prop.JuegoId, prop.ConsolaId });
            modelBuilder.Entity<Genero>().Property(x => x.Nombre).HasField("_Nombre");
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Consola> Consolas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Desarrollador> Desarrolladores { get; set; }
        public DbSet<JuegoConsola> JuegosConsolas { get; set; }
        public DbSet<Publicadora> Publicadoras { get; set; }
        public DbSet<ModosDeJuego> ModosDeJuegos { get; set; }

    }
}
