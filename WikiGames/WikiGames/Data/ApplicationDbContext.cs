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

            modelBuilder.Entity<PersonajeJuegos>().HasKey(prop => new { prop.JuegoId, prop.PersonajeId });

            modelBuilder.Entity<PersonajeJuegos>().Property(prop => prop.TipoPersonaje).HasDefaultValue(TipoPersonaje.Secundario).HasConversion<string>();

            //modelBuilder.Entity<Juego>().HasOne(j => j.Desarrolladora).WithOne().HasForeignKey<Desarrollador>(de => de.DesarrolladorId).IsRequired();
            //modelBuilder.Entity<Juego>().HasOne(j => j.Publicadora).WithOne().HasForeignKey<Publicadora>(de => de.PublicadoraId).IsRequired();

        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Consola> Consolas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Desarrollador> Desarrolladores { get; set; }
        public DbSet<JuegoConsola> JuegosConsolas { get; set; }
        public DbSet<Publicadora> Publicadoras { get; set; }
        public DbSet<ModosDeJuego> ModosDeJuegos { get; set; }
        public DbSet<ImgConsolas> ImgConsolas { get; set; }
        public DbSet<ImgDesarrolladores> ImgDesarrolladores { get; set; }
        public DbSet<PersonajeJuegos> PersonajeJuegos { get; set; }

    }
}
