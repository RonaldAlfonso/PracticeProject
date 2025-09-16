using System.ComponentModel.DataAnnotations;

namespace MiApi.Models;

public class Habilidad
{
    [Key]
    public int id { get; set; }

    public string nombre { get; set; } = string.Empty;

    public List<Mandril> mandriles { get; set; } = new();

    public Epotencia potencia { get; set; }




    public enum Epotencia
    {
        Suave,
        Moderado,
        Intenso,
        Repotente,
        Extremo,
    }

}