namespace WikiGames.Models.Entities
{
    public class Juego
    {
        public int JuegoId { get; set; }
        public string JuegoName { get; set; }
        public List<Genero> Generos { get; set; }  
        
        public HashSet<JuegoConsola> JuegoConsola { get; set; }
        public List<Desarrollador> Desarrolladora { get; set; }

    }
}
