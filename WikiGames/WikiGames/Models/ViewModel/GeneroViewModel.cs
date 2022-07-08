using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.ViewModel
{
    public class GeneroViewModel
    {
        public int GeneroId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; }
    }
}
