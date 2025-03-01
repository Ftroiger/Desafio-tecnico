using Desafio_tecnico.Data;
using Desafio_tecnico.Models;
using Desafio_tecnico.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Desafio_tecnico.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ContextDb _context;

        public ProductoRepository(ContextDb context)
        {
            _context = context;
        }
        public Task Create(Producto producto)
        {
            _context.Productos.Add(producto);
            return _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetById(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.id == id);

            if (producto == null)
            {
                throw new Exception("Producto no encontrado");
            }
            return producto;
        }

        public async Task Update(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }
    }
}
