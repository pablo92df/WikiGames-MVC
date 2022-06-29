using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.ViewModel.DesarrolladoresViewModel
{
    public class DesarrolladorEditViewModel : DesarrolladorViewModel
    {
        [Required]
        public DateTime Creacion { get; set; }
        public DateTime Cierre { get; set; }
        [Required]
        [StringLength(maximumLength: 1000, ErrorMessage = "El nombre no puede ser mayo a {1} catacteres")]

        public string Descripcion { get; set; }
    }
}
