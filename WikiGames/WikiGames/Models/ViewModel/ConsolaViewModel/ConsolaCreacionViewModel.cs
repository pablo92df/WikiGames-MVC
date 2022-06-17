using System.ComponentModel.DataAnnotations;
using WikiGames.Models.Entities;

namespace WikiGames.Models.ViewModel.ConsolaViewModel
{
    public class ConsolaCreacionViewModel : ConsolaViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 1000, ErrorMessage = "El nombre no puede ser mayo a {1} catacteres")]
        public string Descripcion { get; set; }


   
        //public Marca Marca { get; set; }

    }
}
