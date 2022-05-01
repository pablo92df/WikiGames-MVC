using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.Entities
{
    public class Desarrollador
    {
        public int DesarrolladorId { get; set; }
        [MaxLength(50)]
        public string DesarrolladorName { get; set; }
        [MaxLength(500)]
        public string Descripcion { get; set; }
        public DateTime Creacion { get; set; }

        public DateTime? Cierre { get; set; }

        public List<Juego> Juegos { get; set;}

    }
}
