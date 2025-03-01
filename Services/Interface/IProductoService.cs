using Desafio_tecnico.DTO;
using Desafio_tecnico.Models;
using Desafio_tecnico.Response;

namespace Desafio_tecnico.Services.Interfaces
{
    public interface IProductoService
    {
        Task<ApiResponse<List<ProductoDto>>> GetAll();
        Task<ApiResponse<ProductoDto>> GetById(int id);
        Task<ApiResponse<ProductoDto>> Create(ProductoDto productoDto);
        Task<ApiResponse<ProductoDto>> Update(int id, ProductoDto productoDto);
        Task<ApiResponse<ProductoDto>> Delete(int id);
    }
}
