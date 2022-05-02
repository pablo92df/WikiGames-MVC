using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.Entities
{
    public class Consola
    {
        public int ConsolaId { get; set; }
        [MaxLength(50)]

        public string ConsolaName { get; set; }
        [MaxLength(500)]

        public string Descripcion { get; set; }
        public DateTime FechaLanzamiento { get; set; }

        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public HashSet<JuegoConsola> JuegoConsola { get; set; }


    }
}
