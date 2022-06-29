using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.ViewModel.PublicadoraViewModel
{
    public class PublicadoraEditViewModel:PublicadoraViewModel
    {
        [Required]
        public DateTime Fundacion { get; set; }
        [Required]
        [StringLength(maximumLength:1000, ErrorMessage = "La descripcion no puede ser mayo a {1} catacteres")]
        [Display(Name = "Descripcion")]
        public string Historia { get; set; }

    }
}
