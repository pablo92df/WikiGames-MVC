using WikiGames.Models.ViewModel.JuegoViewModel;
using WikiGames.Models.Entities;

namespace WikiGames.Models.ViewModel.JuegosConsolaViewModel
{
    public class JCJuegosListViewModel
    {
        public int JuegoId { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CopiasVendidas { get; set; }
        public JuegoInfoJCViewModel Juego { get; set; }

    }
}
