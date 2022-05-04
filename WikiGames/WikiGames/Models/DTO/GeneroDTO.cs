using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.DTO
{
    public class GeneroDTO
    {
        public int GeneroId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre;
    }
}
