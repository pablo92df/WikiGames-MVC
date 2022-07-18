using WikiGames.Models.ViewModel.JuegosConsolaViewModel;
using WikiGames.Models.Entities;
using WikiGames.Models.ViewModel.JuegoViewModel;
using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.ViewModel.JuegViewModel
{
    public class JuegoCreacionViewModel : JuegosViewModel
    {

        [Required]
        [Display(Name = "Descripcion")]
        [StringLength(maximumLength:1000, ErrorMessage = "La descripcion no puede ser mayo a {1} catacteres")]

        public string JuegoDescription { get; set; }
        
        public int DesarrolladoraId { get; set; }
        public int PublicadoraId { get; set; }
        [Required]
        [StringLength(maximumLength: 1000, ErrorMessage = "El argumento no puede ser mayor a {1} catacteres")]
        public string Argumento { get; set; }

        [Required]

        public List<Genero> Generos { get; set; }
        public List<JuegoConsolaViewModel> JuegosConsolaDTO { get; set; }
        public List<ModosDeJuego> ModosDeJuegos { get; set; }
        public List<Personaje> Personajes { get; set; }


    }
}
