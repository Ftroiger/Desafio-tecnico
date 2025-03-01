using Desafio_tecnico.Models;

namespace Desafio_tecnico.Repository.Interface
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAll();
        Task<Producto> GetById(int id);
        Task Create(Producto producto);
        Task Update(Producto producto);
        Task Delete(int id);
    }
}
