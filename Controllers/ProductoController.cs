using Desafio_tecnico.Data;
using Desafio_tecnico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_tecnico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ContextDb _context;

        public ProductoController(ContextDb context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }
        
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, Producto producto)
        {
            if (id != producto.id)
            {
                return BadRequest();
            }
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(producto);
        }
    }
}
