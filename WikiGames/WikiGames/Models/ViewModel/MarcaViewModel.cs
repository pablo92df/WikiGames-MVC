using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.ViewModel
{
    public class MarcaViewModel
    {
        public int MarcaId { get; set; }
        [Required, MaxLength(50)]
        public string MarcaName { get; set; }
    }
}
