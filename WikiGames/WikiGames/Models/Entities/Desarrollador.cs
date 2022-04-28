namespace WikiGames.Models.Entities
{
    public class Desarrollador
    {
        public int DesarrolladorId { get; set; }
        public string DesarrolladorName { get; set; }
        
        public string Descripcion { get; set; }
        public DateTime Creacion { get; set; }

        public DateTime? Cierre { get; set; }

        public List<Juego> Juegos { get; set;}

    }
}
