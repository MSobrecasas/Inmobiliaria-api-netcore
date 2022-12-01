using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Context;
using Inmobiliaria.Models;
using Inmobiliaria.Models.DTO;
using NuGet.Protocol;
using Microsoft.Extensions.Hosting;

namespace Inmobiliaria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InmueblesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inmueble>>> getDetails()
        {
            return await _context.Inmueble.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Inmueble>> Details(int? id)
        {
            if (id == null || _context.Inmueble == null)
            {
                return Content("No existe");
            }

            var inmueble = await _context.Inmueble
                .FirstOrDefaultAsync(m => m.id_inmueble == id);
            if (inmueble == null)
            {
                return Content("No existe");
            }

            return inmueble;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Inmueble inmueble)
        {
            if (id != inmueble.id_inmueble)
            {
                return Content("Id no conicide");
            }
            _context.Entry(inmueble).State = EntityState.Modified;

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
            var inmueble = await _context.Inmueble.FindAsync(id);
            if (inmueble == null)
            {
                return Content("No Existe");
            }
            _context.Inmueble.Remove(inmueble);
            await _context.SaveChangesAsync();

            return Content("Borrado Correctamente");

        }


        [HttpPost]
        public async Task<ActionResult<Inmueble>> Create(InmuebleDto inmuebleDto)
        {
            try
            {
                var tipoInmueble = await _context.TipoInmueble.FindAsync(inmuebleDto.id_tipo_inmueble);
                if(tipoInmueble == null)
                {
                    return Content("Tipo de inmueble no existe");
                }

                var inmueble = new Inmueble
                {
                    desc_inmueble = inmuebleDto.desc_inmueble,
                    ubic_inmueble = inmuebleDto.ubic_inmueble,
                    costo_inmueble = inmuebleDto.costo_inmueble,
                    tipoInmueble = tipoInmueble
                };

                _context.Inmueble.Add(inmueble);
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
            return _context.Inmueble.Any(e => e.id_inmueble == id);
        }

    }
}
