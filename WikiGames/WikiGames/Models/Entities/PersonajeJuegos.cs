namespace WikiGames.Models.Entities
{
    public class PersonajeJuegos
    {
        public int PersonajeId { get; set; }
        public Personaje Personaje { get; set; }
        public int JuegoId { get; set; }
        public Juego Juego { get; set; }

        public string Descripcion { get; set; }
        public string TipoPersonaje { get; set; }

    }
}
