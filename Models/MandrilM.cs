using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MiApi.Models;

public class Mandril
{
    public int id { get; set; }

    public string nombre { get; set; } = string.Empty;
    
    public string apellido { get; set; } = string.Empty;

    [AllowNull]
    public List<Habilidad> Habilidades { get; set; }

}