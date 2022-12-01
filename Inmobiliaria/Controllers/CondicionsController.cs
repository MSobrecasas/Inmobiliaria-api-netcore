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
    public class CondicionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CondicionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condicion>>> getDetails()
        {
            return await _context.Condicion.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Condicion>> Details(int? id)
        {
            if (id == null || _context.Condicion == null)
            {
                return Content("No existe");
            }

            var condicion = await _context.Condicion
                .FirstOrDefaultAsync(m => m.id_condicion == id);
            if (condicion == null)
            {
                return Content("No existe");
            }

            return condicion;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Condicion condicion)
        {
            if (id != condicion.id_condicion)
            {
                return Content("Id no conicide");
            }
            _context.Entry(condicion).State = EntityState.Modified;

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
            var condicion = await _context.Condicion.FindAsync(id);
            if (condicion == null)
            {
                return Content("No Existe");
            }
            _context.Condicion.Remove(condicion);
            await _context.SaveChangesAsync();

            return Content("Borrado Correctamente");

        }


        [HttpPost]
        public async Task<ActionResult<Condicion>> Create(Condicion condicion)
        {
            try
            {

                _context.Condicion.Add(condicion);
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
            return _context.Condicion.Any(e => e.id_condicion == id);
        }
    }
}
