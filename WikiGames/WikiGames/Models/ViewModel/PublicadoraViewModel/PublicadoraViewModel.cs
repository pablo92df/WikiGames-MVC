using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.ViewModel.PublicadoraViewModel
{
    public class PublicadoraViewModel
    {
        public int PublicadoraId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre no puede ser mayo a {1} catacteres")]
        public string PublicadoraNombre { get; set; }
    }
}
