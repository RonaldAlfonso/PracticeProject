using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MiApi.Models;
using MiApi.Data;
using MiApi.Dtos;
namespace MiApi.Controllers;



[ApiController]
[Route("api/[controller]")]

public class MandrilController : ControllerBase
{
    private readonly AppDbContext _context; // _context es una variable de instancia privada que representa tu base de datos.
                                            // readonly no se puede reasignar después del constructor.

    public MandrilController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Mandril>>> GetMandrils()
    {
        var mandrils = await _context.Mandrils.ToListAsync();
        return Ok(mandrils);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Mandril>> GetMandril(int id)
    {
        var mandril = await _context.Mandrils.FindAsync(id);
        if (mandril == null) return NotFound();
        return Ok(mandril); 
    }

    [HttpPost]
    public async Task<ActionResult<Mandril>> CreateMandril(MandrilCreateUpdateDto dto)
    {
        var mandril = new Mandril
        {
            nombre = dto.Nombre,
            apellido = dto.Apellido
        };

        _context.Mandrils.Add(mandril);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMandril), new { id = mandril.id }, mandril);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMandril(int id, [FromBody]MandrilCreateUpdateDto dto)
    {
        var mandril = await _context.Mandrils
            .Include(m => m.Habilidades)
            .FirstOrDefaultAsync(m => m.id == id);

        if (mandril == null)
            return NotFound();

        mandril.nombre = dto.Nombre;
        mandril.apellido = dto.Apellido;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMandril(int id)
    {
        var mandril = await _context.Mandrils.FindAsync(id);
        if (mandril == null) return NotFound(); 

        _context.Mandrils.Remove(mandril);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
}


// public class MandrilController : ControllerBase
// {
//     [HttpGet]
//     public ActionResult<IEnumerable<Mandril>> GetMandriles()
//     {
//         return Ok(MandrilDataStore.Current.Mandriles);
//     }

//     [HttpGet("{mandrilId}")]
//     public ActionResult<Mandril> GetMandril(int mandrilId)
//     {
//         var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilId);

//         if (mandril == null)
//         {
//             return NotFound("el mandril  solicitado no existe");
//         }
//         return Ok(mandril);
//     }
//     [HttpPost]
//     public ActionResult<Mandril> PostMandril(MandrilInsert mandrilinsert)
//     {
//         var mandrilid = MandrilDataStore.Current.Mandriles.Max(x => x.id);

//         var newmandril = new Mandril()
//         {
//             id = mandrilid += 1,
//             nombre = mandrilinsert.name,
//             apellido = mandrilinsert.apellido

//         };
//         MandrilDataStore.Current.Mandriles.Add(newmandril);

//         return CreatedAtAction((nameof(GetMandril)),
//         new { mandrilid = newmandril.id },
//         newmandril);
//         ;
//     }
//     [HttpPut("{mandrilid}")]
//     public ActionResult<Mandril> PutMandril([FromRoute] int mandrilid, [FromBody] MandrilInsert mandrilinsert)
//     {
//         var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilid);
//         if (mandril == null)
//         {
//             return NotFound("El mandril que busca no existe");
//         }
//         mandril.nombre = mandrilinsert.name;
//         mandril.apellido = mandrilinsert.apellido;

//         return NoContent();
//     }

//     [HttpDelete("{mandrilid}")]
//     public ActionResult<Mandril> DeleteMandril(int mandrilid)
//     {
//         var mandrilAEliminar = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.id == mandrilid);
//         if (mandrilAEliminar == null)
//         {
//             return NotFound("El mandril que querias eliminar no existe");
//         }
//         MandrilDataStore.Current.Mandriles.Remove(mandrilAEliminar);
//         return Ok();
//     }

// }