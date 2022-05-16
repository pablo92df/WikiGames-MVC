using WikiGames.Models.DTO.JuegosConsola;
using WikiGames.Models.Entities;

namespace WikiGames.Models.DTO.Juego
{
    public class JuegoCreacionDTO
    {
        public int JuegoId { get; set; }
        public string JuegoName { get; set; }
        public string JuegoDescription { get; set; }
        public DateTime FechaLanzamientoOficial { get; set; }
        public List<int> Generos { get; set; }
        public int DesarrolladoraId { get; set; }
        public int PublicadoraId { get; set; }
        public string Argumento { get; set; }
        public List<JuegoConsolaDTO> JuegosConsolaDTO { get; set; }
        public List<ModosDeJuego> ModosDeJuegos { get; set; }
        public List<Personaje> Personajes { get; set; }
    }
}
