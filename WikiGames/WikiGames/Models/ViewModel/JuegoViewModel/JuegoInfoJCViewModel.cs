using WikiGames.Models.Entities;

namespace WikiGames.Models.ViewModel.JuegoViewModel
{
    public class JuegoInfoJCViewModel
    {
        public int JuegoId { get; set; }
      
        public string JuegoName { get; set; }

        public List<Genero> Generos { get; set; }

        public List<ModosDeJuego> ModosDeJuegos { get; set; }

    }
}
