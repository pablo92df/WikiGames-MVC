using System.ComponentModel.DataAnnotations;


namespace WikiGames.Models.ViewModel.DesarrolladoresViewModel
{
    public class DesarrolladorCreacionViewModel : DesarrolladorViewModel
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 1000, ErrorMessage = "El nombre no puede ser mayo a {1} catacteres")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Fecha Creacion")]
        [DataType(DataType.Date)]
        public DateTime Creacion { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Cierre { get; set; }

        public int ImgDesarrolladorId { get; set; }
        


    }
}
