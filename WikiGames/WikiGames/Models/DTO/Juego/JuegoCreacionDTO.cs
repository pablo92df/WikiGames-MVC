using WikiGames.Models.DTO.JuegosConsola;



namespace WikiGames.Models.DTO.Juego
{
    public class JuegoCreacionDTO
    {
        public int JuegoId { get; set; }
        public string JuegoName { get; set; }

        public string Descripcion { get; set; }
        public DateTime FechaLanzamientoOficial { get; set; }
        public List<int> Generos { get; set; }
        public List<JuegoConsolaDTO> JuegosConsolaDTO { get; set; }
    }
}
