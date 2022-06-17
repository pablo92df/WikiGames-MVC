using WikiGames.Models.ViewModel.JuegoViewModel;
using WikiGames.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.ViewModel.DesarrolladoresViewModel
{
    public class DesarrolladorViewModel
    {
        public int DesarrolladorId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre no puede ser mayo a {1} catacteres")]
        public string DesarrolladorName { get; set; }

        public ImgDesarrolladores ImgDesarrolladores { get; set; }
    }
}
