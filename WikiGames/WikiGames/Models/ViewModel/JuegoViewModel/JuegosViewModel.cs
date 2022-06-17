using WikiGames.Models.Entities;

namespace WikiGames.Models.ViewModel.JuegoViewModel
{
    public class JuegosViewModel
    {
        public int JuegoId { get; set; }
        public string JuegoName { get; set; }
        public DateTime FechaLanzamientoOficial { get; set; }
        public Desarrollador Desarrolladora { get; set; }
        public Publicadora  Publicadora  { get; set; }
    }
}
