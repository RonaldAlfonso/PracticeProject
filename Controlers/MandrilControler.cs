using Microsoft.AspNetCore.Mvc;
using MiApi.Models;
using MiApi.Services;
namespace MiApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetMandriles()
    {
        return Ok(MandrilDataStore.Current.Mandriles);
    }

    [HttpGet("{mandrilId}")]
    public ActionResult<Mandril> GetMandril(int mandrilId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilId);

        if (mandril == null)
        {
            return NotFound("el mandril  solicitado no existe");
        }
        return Ok(mandril);
    }
    [HttpPost]
    public ActionResult<Mandril> PostMandril(MandrilInsert mandrilinsert)
    {
        var mandrilid = MandrilDataStore.Current.Mandriles.Max(x => x.id);

        var newmandril = new Mandril()
        {
            id = mandrilid += 1,
            nombre = mandrilinsert.name,
            apellido = mandrilinsert.apellido

        };
        MandrilDataStore.Current.Mandriles.Add(newmandril);

        return CreatedAtAction((nameof(GetMandril)),
        new { mandrilid = newmandril.id },
        newmandril);
        ;
    }
    [HttpPut]
    public ActionResult<Mandril> PutMandril([FromRoute] int mandrilid, [FromBody] MandrilInsert mandrilinsert)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilid);
        if (mandril == null)
        {
            return NotFound("El mandril que busca no existe");
        }
        mandril.nombre = mandrilinsert.name;
        mandril.apellido = mandril.apellido;

        return NoContent();
    }

}