using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Context;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Inmobiliaria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FormaPagoesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public FormaPagoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormaPago>>> getDetails()
        {
            return await _context.FormaPago.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<FormaPago>> Details(int? id)
        {
            if (id == null || _context.FormaPago == null)
            {
                return Content("No existe");
            }

            var formaPago = await _context.FormaPago
                .FirstOrDefaultAsync(m => m.id_forma_pago == id);
            if (formaPago == null)
            {
                return Content("No existe");
            }

            return formaPago;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, FormaPago formaPago)
        {
            if (id != formaPago.id_forma_pago)
            {
                return Content("Id no conicide");
            }
            _context.Entry(formaPago).State = EntityState.Modified;

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
            var formaPago = await _context.FormaPago.FindAsync(id);
            if (formaPago == null)
            {
                return Content("No Existe");
            }
            _context.FormaPago.Remove(formaPago);
            await _context.SaveChangesAsync();

            return Content("Borrado Correctamente");

        }


        [HttpPost]
        public async Task<ActionResult<FormaPago>> Create(FormaPago formaPago)
        {
            try
            {
                _context.FormaPago.Add(formaPago);
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
            return _context.FormaPago.Any(e => e.id_forma_pago == id);
        }
    }
}
