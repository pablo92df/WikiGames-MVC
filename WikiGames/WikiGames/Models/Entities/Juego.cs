using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.Entities
{
    public class Juego
    {
        public int JuegoId { get; set; }
        [MaxLength(50)]

        public string JuegoName { get; set; }
        [MaxLength(500)]
        public string JuegoDescription { get; set; }    
        public List<Genero> Generos { get; set; }  
        
        public HashSet<JuegoConsola> JuegoConsola { get; set; }
        public List<Desarrollador> Desarrolladora { get; set; }

    }
}
