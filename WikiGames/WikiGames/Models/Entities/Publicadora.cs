namespace WikiGames.Models.Entities
{
    public class Publicadora
    {
        public int PublicadoraId { get; set; }
        public string PublicadoraNombre { get; set; }
        public DateTime Fundacion { get; set; }
        public string Historia { get; set; }

        public List<Juego> Juegos { get; set; }
    }
}
