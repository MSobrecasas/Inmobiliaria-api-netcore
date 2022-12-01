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
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> getDetails()
        {
            return await _context.Cliente.ToListAsync();
        }

        // GET: Clientes/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Details(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return Content("No existe");
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.id_cliente == id);
            if (cliente == null)
            {
                return Content("No existe");
            }

            return cliente;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditCliente(int id, Cliente cliente)
        {
            if (id != cliente.id_cliente)
            {
                return Content("Id no conicide");
            }
            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content("Editado  Correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return Content("No existe");
            }
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return Content("Borrado Correctamente"); ;

        }


        [HttpPost]
        public async Task<ActionResult<Cliente>> CreateCliente(Cliente cliente)
        {
            try
            {
                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();

                return Content("Creado  Correctamente");
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Problem(e.ToString());
            }
        }

        private bool ClienteExiste(int id)
        {
            return _context.Cliente.Any(e => e.id_cliente == id);
        }

    }
}
