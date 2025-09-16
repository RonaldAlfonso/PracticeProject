using Microsoft.AspNetCore.Mvc;
using MiApi.Models;
using MiApi.Services;
using MiApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MiApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    private readonly AppDbContext _context;

    public MandrilController(AppDbContext context)
    {
        _context = context;
    }




    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetMandriles()
    {
        return Ok( _context.Mandriles.ToList());
    }

    [HttpGet("{mandrilId}")]
    public ActionResult<Mandril> GetMandril(int mandrilId)
    {
        var mandril = _context.Mandriles.Find(mandrilId);

        if (mandril == null)
        {
            return NotFound("el mandril  solicitado no existe");
        }
        return Ok(mandril);
    }
    [HttpPost]
    public async Task<ActionResult<Mandril>> PostMandril([FromBody]MandrilInsert mandrilinsert)
    {
        
        if (mandrilinsert == null)
        {
            return BadRequest();
        }

        var newmandril = new Mandril()
        {
            
            nombre = mandrilinsert.name,
            apellido = mandrilinsert.apellido

        };
        _context.Mandriles.Add(newmandril);
        await _context.SaveChangesAsync();

        return CreatedAtAction((nameof(GetMandril)),
        new { mandrilid = newmandril.id },
        newmandril);
        ;
    }
    [HttpPut("{mandrilid}")]
    public async Task<ActionResult> PutMandril([FromRoute] int mandrilid, [FromBody] MandrilInsert mandrilinsert)
    {
        if (mandrilinsert == null)
        {
            return BadRequest();
        }
        var mandril = _context.Mandriles.Find(mandrilid);
        if (mandril == null)
        {
            return NotFound("El mandril que busca no existe");
        }
        mandril.nombre = mandrilinsert.name;
        mandril.apellido = mandrilinsert.apellido;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{mandrilid}")]
    public async Task<ActionResult<Mandril>> DeleteMandril(int mandrilid)
    {
        var mandrilAEliminar = _context.Mandriles.Find(mandrilid);
        if (mandrilAEliminar == null)
        {
            return NotFound("El mandril que querias eliminar no existe");
        }
         _context.Mandriles.Remove(mandrilAEliminar);
        await _context.SaveChangesAsync();
        return Ok();
    }

}