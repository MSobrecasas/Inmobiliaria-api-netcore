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

namespace Inmobiliaria.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> getDetails()
        {
            return await _context.Venta.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> Details(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return Content("No existe");
            }

            var venta = await _context.Venta
                .FirstOrDefaultAsync(m => m.id_venta == id);
            if (venta == null)
            {
                return Content("No existe");
            }

            return venta;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Venta venta)
        {
            if (id != venta.id_venta)
            {
                return Content("Id no conicide");
            }
            _context.Entry(venta).State = EntityState.Modified;

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
            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
            {
                return Content("No Existe");
            }
            _context.Venta.Remove(venta);
            await _context.SaveChangesAsync();

            return Content("Borrado Correctamente");

        }


        [HttpPost]
        public async Task<ActionResult<Venta>> Create(VentaDto ventaDto)
        {
            try
            {
                var inmueble = await _context.Inmueble.FindAsync(ventaDto.id_inmueble);
                if (inmueble == null)
                {
                    return Content("Inmueble no existe");
                }

                var cliente = await _context.Cliente.FindAsync(ventaDto.id_cliente);
                if (cliente == null)
                {
                    return Content("Cliente no existe");
                }

                var condicion = await _context.Condicion.FindAsync(ventaDto.id_condicion);
                if (inmueble == null)
                {
                    return Content("Condicion no existe");
                }

                var formaPago = await _context.FormaPago.FindAsync(ventaDto.id_forma_pago);
                if (formaPago == null)
                {
                    return Content("Forma de Pago no existe");
                }


                var venta = new Venta
                {
                    id_inmueble = ventaDto.id_inmueble,
                    id_cliente = ventaDto.id_cliente,
                    id_condicion = ventaDto.id_condicion,
                    id_forma_pago = ventaDto.id_forma_pago,
                    desc_venta = ventaDto.desc_venta,
                    total_venta = ventaDto.total_venta,
                    total_iva = ventaDto.total_iva,
                    total_general = ventaDto.total_general,
                    fecha_venta = ventaDto.fecha_venta
                };

                _context.Venta.Add(venta);
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
            return _context.Venta.Any(e => e.id_venta == id);
        }
    }
}
