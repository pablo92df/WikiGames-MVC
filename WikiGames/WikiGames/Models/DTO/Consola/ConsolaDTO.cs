using WikiGames.Models.Entities;

namespace WikiGames.Models.DTO.Consola
{
    public class ConsolaDTO
    {
        public int ConsolaId { get; set; }
        public string ConsolaName { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        //public HashSet<JuegoConsola> JuegoConsola { get; set; }
    }
}
