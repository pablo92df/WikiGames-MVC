using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.Entities
{
    public class Consola
    {
        public int ConsolaId { get; set; }
        [Required,MaxLength(50)]

        public string ConsolaName { get; set; }
        [Required,MaxLength(500)]

        public string Descripcion { get; set; }
        
        public DateTime FechaLanzamiento { get; set; }
        [Required]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public List<JuegoConsola> JuegoConsola { get; set; }

    }
}
