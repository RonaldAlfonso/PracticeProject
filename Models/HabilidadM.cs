namespace MiApi.Models;

public class Habilidad
{
    public int id { get; set; }

    public string nombre { get; set; } = string.Empty;

    public Epotencia potencia{ get; set; }




    public enum Epotencia
    {
        Suave,
        Moderado,
        Intenso,
        Repotente,
        Extremo,
    }

}