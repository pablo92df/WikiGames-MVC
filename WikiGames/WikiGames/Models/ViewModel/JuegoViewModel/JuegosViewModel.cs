using System.ComponentModel.DataAnnotations;
using WikiGames.Models.Entities;

namespace WikiGames.Models.ViewModel.JuegoViewModel
{
    public class JuegosViewModel
    {
        public int JuegoId { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre no puede ser mayo a {1} catacteres")]

        public string JuegoName { get; set; }
        public DateTime FechaLanzamientoOficial { get; set; }
        public Desarrollador Desarrolladora { get; set; }
        public Publicadora  Publicadora  { get; set; }
    }
}
