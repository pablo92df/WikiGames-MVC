using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.Entities
{
    public class Juego
    {
        public int JuegoId { get; set; }
        [Required, MaxLength(50)]
        public string JuegoName { get; set; }
        [MaxLength(500)]
        public string JuegoDescription { get; set; }
        
        public DateTime FechaLanzamientoOficial { get; set; }
        public List<Genero> Generos { get; set; }  
        
        public List<JuegoConsola> JuegoConsola { get; set; }
        public List<Desarrollador> Desarrolladora { get; set; }

    }
}
