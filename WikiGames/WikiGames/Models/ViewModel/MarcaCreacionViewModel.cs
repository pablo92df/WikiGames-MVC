using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.ViewModel
{
    public class MarcaCreacionViewModel
    {
        [Required, MaxLength(50)]
        public string MarcaName { get; set; }
    }
}
