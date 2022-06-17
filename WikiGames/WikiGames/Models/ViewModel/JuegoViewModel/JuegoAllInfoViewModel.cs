using WikiGames.Models.Entities;

namespace WikiGames.Models.ViewModel.JuegoViewModel
{
    public class JuegoAllInfoViewModel:JuegosViewModel
    {
        public List<Genero> Generos { get; set; }
        public List<JuegoConsola> JuegoConsola { get; set; }
        public string Descripcion { get; set; }

    }
}
