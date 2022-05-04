using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.DTO
{
    public class MarcaDTO
    {
        public int MarcaId { get; set; }
        [Required, MaxLength(50)]
        public string MarcaName { get; set; }
    }
}
