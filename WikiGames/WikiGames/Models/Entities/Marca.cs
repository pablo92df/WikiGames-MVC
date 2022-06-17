using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.Entities
{
    public class Marca
    {
        public int MarcaId { get; set; }
        [Required, MaxLength(50)]
        public string MarcaName { get; set;}

        public List<Consola> Consola { get; set; }
    }
}
