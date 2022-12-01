using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Context;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class TipoInmueblesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoInmueblesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoInmueble>>> getDetails()
        {
            return await _context.TipoInmueble.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TipoInmueble>> Details(int? id)
        {
            if (id == null || _context.TipoInmueble == null)
            {
                return Content("No existe");
            }

            var tipoInmueble = await _context.TipoInmueble
                .FirstOrDefaultAsync(m => m.id_tipo_inmueble == id);
            if (tipoInmueble == null)
            {
                return Content("No existe");
            }

            return tipoInmueble;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, TipoInmueble tipoInmueble)
        {
            if (id != tipoInmueble.id_tipo_inmueble)
            {
                return Content("Id no conicide");
            }
            _context.Entry(tipoInmueble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!Existe(id))
                {
                    return Problem(e.ToString());
                }
                else
                {
                    throw;
                }
            }

            return Content("Editado  Correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoInmueble = await _context.TipoInmueble.FindAsync(id);
            if (tipoInmueble == null)
            {
                return Content("No Existe");
            }
            _context.TipoInmueble.Remove(tipoInmueble);
            await _context.SaveChangesAsync();

            return Content("Borrado Correctamente");

        }


        [HttpPost]
        public async Task<ActionResult<TipoInmueble>> Create(TipoInmueble tipoInmueble)
        {
            try
            {
                _context.TipoInmueble.Add(tipoInmueble);
                await _context.SaveChangesAsync();

                return Content("Creado  Correctamente");

            }
            catch (DbUpdateConcurrencyException e)
            {
                return Problem(e.ToString());
            }
        }

        private bool Existe(int id)
        {
            return _context.TipoInmueble.Any(e => e.id_tipo_inmueble == id);
        }
    }
}
