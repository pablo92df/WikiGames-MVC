using System.ComponentModel.DataAnnotations;

namespace WikiGames.Models.Entities
{
    public class Genero
    {
        public int GeneroId { get; set; }

        [Required,MaxLength(50)]
        private string _Nombre;

        public string Nombre { 
            get
            {
                return _Nombre;        
            } 
            set
            {
                _Nombre = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToArray());
            }
        }
    }
}
