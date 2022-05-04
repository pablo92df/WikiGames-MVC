using WikiGames.Models.Entities;

namespace WikiGames.Models.DTO.Juego
{
    public class JuegosDTO
    {
        public int JuegoId { get; set; }
        public string JuegoName { get; set; }
        public DateTime FechaLanzamientoOficial { get; set; }
        public List<Genero> Generos { get; set; }
        public HashSet<JuegoConsola> JuegoConsola { get; set; }


    }
}
