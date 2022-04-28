namespace WikiGames.Models.Entities
{
    public class JuegoConsola
    {
        public int JuegoId { get; set; }
        public int ConsolaId { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CopiasVendidas { get; set; }
        public Juego Juego { get; set; }
        public Consola Consola { get; set; }   
    }
}
