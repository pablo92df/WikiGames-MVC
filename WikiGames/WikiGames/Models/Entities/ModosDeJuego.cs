namespace WikiGames.Models.Entities
{
    public class ModosDeJuego
    {
        public int ModosDeJuegoId { get; set; }
        public string ModosDeJuegoName { get; set; }

        public string Descripcion { get; set; }
        public List<Juego> Juegos { get; set; }
    }
}
