using Desafio_tecnico.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_tecnico.Data
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }

}
