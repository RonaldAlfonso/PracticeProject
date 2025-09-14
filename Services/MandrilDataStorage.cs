using MiApi.Models;

namespace MiApi.Services;

public class MandrilDataStore
{
    public List<Mandril> Mandriles { get; set; }
    public static MandrilDataStore Current { get; } = new MandrilDataStore();
    public MandrilDataStore()
    {
        Mandriles = new List<Mandril>()
        {

            new Mandril()
            {
                id=1,
                nombre="mini mandril",
                apellido="rodriguez",
                Habilidades=new List<Habilidad>()
                {
                    new Habilidad()
                    {
                        id=1,
                        nombre="Super Berro",
                        potencia=Habilidad.Epotencia.Extremo
                    }
                }

            },
            new Mandril()
            {
                id=2,
                nombre="FM",
                apellido="Fernandez",
                Habilidades=new List<Habilidad>()
                {
                    new Habilidad()
                    {
                        id=2,
                        nombre="Super Amor",
                        potencia=Habilidad.Epotencia.Moderado
                    }
                }
            }

        };
    }
    
}