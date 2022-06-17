using WikiGames.Models.ViewModel.JuegosConsolaViewModel;
using WikiGames.Models.Entities;
using WikiGames.Models.ViewModel.JuegoViewModel;

namespace WikiGames.Models.ViewModel.JuegViewModel
{
    public class JuegoCreacionViewModel : JuegosViewModel
    {
  
        public string JuegoDescription { get; set; }
        public int DesarrolladoraId { get; set; }
        public int PublicadoraId { get; set; }
        public string Argumento { get; set; }
        public List<Genero> Generos { get; set; }
        public List<JuegoConsolaViewModel> JuegosConsolaDTO { get; set; }
        public List<ModosDeJuego> ModosDeJuegos { get; set; }
        public List<Personaje> Personajes { get; set; }
    }
}
