namespace WikiGames.Models.Entities
{
    public class Genero
    {
        public int GeneroId { get; set; }
        [MaxLength(50)]

        public string Nombre { get; set; }
    }
}
