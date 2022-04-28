namespace WikiGames.Models.Entities
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string MarcaName { get; set;}

        public Consola Consola { get; set; }
    }
}
