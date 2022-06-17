using WikiGames.Models.ViewModel.JuegosConsolaViewModel;
using WikiGames.Models.Entities;

namespace WikiGames.Models.ViewModel.ConsolaViewModel
{
    public class ConsolaAllInfoViewModel : ConsolaViewModel
    {
        public string Descripcion { get; set; }
        public List<JCJuegosListViewModel> juegoConsola { get; set; }

    }
}
