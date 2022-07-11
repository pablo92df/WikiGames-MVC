using System.ComponentModel.DataAnnotations;
using WikiGames.Models.Entities;

namespace WikiGames.Models.ViewModel.ConsolaViewModel
{
    public class ConsolaViewModel
    {
        public int ConsolaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre no puede ser mayo a {1} catacteres")]
        [Display(Name = "Nombre de la Consola")]
        public string ConsolaName { get; set; }

        [Display(Name = "Fecha Lanzamiento")]
        [DataType(DataType.Date)] 
        public DateTime FechaLanzamiento { get; set; }

        [Range(1, maximum: int.MaxValue, ErrorMessage = "Debe seleccionar una Marca")]
        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }
        public int ImgConsolasId { get; set; }
        public ImgConsolas?  imgConsolas { get; set; }

    }
}
