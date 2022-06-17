namespace WikiGames.Models.Entities
{
    public class Personaje
    {
        public int PersonajeId { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public List<Juego> JuegoList { get; set;}

    }
}
