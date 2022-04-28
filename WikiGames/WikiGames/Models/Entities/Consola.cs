namespace WikiGames.Models.Entities
{
    public class Consola
    {
        public int ConsolaId { get; set; } 
        public string ConsolaName { get; set; }

        public string Descripcion { get; set; }
        public DateTime FechaLanzamiento { get; set; }

        public int MarcaId { get; set; }

        public HashSet<JuegoConsola> JuegoConsola { get; set; }


    }
}
