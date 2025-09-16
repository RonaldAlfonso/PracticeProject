using System.ComponentModel.DataAnnotations;
using MiApi.Models;

namespace MiApi.Dtos
{
    public class MandrilCreateUpdateDto
    {
        public int? id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }
        
        public List<Habilidad>? Habilidades { get; set; }
    }
}