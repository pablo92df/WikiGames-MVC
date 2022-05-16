using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.Entities
{
    public class Juego
    {
        public int JuegoId { get; set; }
        [Required, MaxLength(50)]
        public string JuegoName { get; set; }
        [MaxLength(10000)]
        public string JuegoDescription { get; set; }
        
        public DateTime FechaLanzamientoOficial { get; set; }
        public List<Genero> Generos { get; set; }  
        
        public List<JuegoConsola> JuegoConsola { get; set; }
        public Desarrollador Desarrolladora { get; set; }
        public Publicadora Publicadora { get; set; }

        public string Argumento { get; set; }

        public List<ModosDeJuego> ModosDeJuegos { get; set; }
        public List<Personaje> Personajes { get; set; }


    }
}
