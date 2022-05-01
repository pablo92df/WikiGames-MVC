using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.Entities
{
    public class Marca
    {
        public int MarcaId { get; set; }
        [MaxLength(50)]
        public string MarcaName { get; set;}

        public Consola Consola { get; set; }
    }
}
