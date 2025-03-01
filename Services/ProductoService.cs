using AutoMapper;
using Desafio_tecnico.DTO;
using Desafio_tecnico.Models;
using Desafio_tecnico.Repository.Interface;
using Desafio_tecnico.Response;
using Desafio_tecnico.Services.Interfaces;
using System.Net;

namespace Desafio_tecnico.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<ProductoDto>>> GetAll()
        {
            var response = new ApiResponse<List<ProductoDto>>();

            try
            {
                var productos = await _productoRepository.GetAll();

                if (
                    productos != null || 
                    productos.Count > 0
                 )
                {
                    response.data = _mapper.Map<List<ProductoDto>>(productos);
                }
                else
                {
                    response.SetError("No se encontraron productos", HttpStatusCode.NotFound);
                }      

            } catch (Exception e)
            {
                response.SetError(e.Message, HttpStatusCode.InternalServerError);
            }

            return response;
        }

        public async Task<ApiResponse<ProductoDto>> GetById(int id)
        {
            var response = new ApiResponse<ProductoDto>();
            try
            {
                var producto = await _productoRepository.GetById(id);

                if (producto != null)
                {
                    response.data = _mapper.Map<ProductoDto>(producto);
                }
                else
                {
                    response.SetError("Producto no encontrado", HttpStatusCode.NotFound);
                }
                    
            } catch (Exception e)
            {
                response.SetError(e.Message, HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponse<ProductoDto>> Create(ProductoDto productoDto)
        {
            var response = new ApiResponse<ProductoDto>();
            try
            {
                var producto = _mapper.Map<Producto>(productoDto);

                if (validateDto(productoDto))
                {
                    await _productoRepository.Create(producto);
                    response.data = productoDto;
                }
                else
                {
                    response.SetError("Error al insertar producto", HttpStatusCode.BadRequest);
                }
                
                
            } catch (Exception e)
            {
                response.SetError(e.Message, HttpStatusCode.InternalServerError);            
            }
            return response;
        }

        private bool validateDto(ProductoDto productoDto)
        {
            if (
                productoDto.name == null ||
                productoDto.description == null ||
                productoDto.price <= 0 ||
                productoDto.quantity <= 0
                )
            {
                return false;
            }
            return true;
        }

        public async Task<ApiResponse<string>> Delete(int id)
        {
            var response = new ApiResponse<string>();
            try
            {
                var producto = await _productoRepository.GetById(id);

                if (producto == null)
                {
                    response.SetError("Producto no encontrado", HttpStatusCode.NotFound);
                    return response;
                }
                await _productoRepository.Delete(id);
                response.data = "Producto eliminado exitosamente";

            } catch (Exception e)
            {
                response.SetError(e.Message, HttpStatusCode.InternalServerError);
            }
            return response;
        }


        public async Task<ApiResponse<ProductoDto>> Update(int id, ProductoDto productoDto)
        {
            var response = new ApiResponse<ProductoDto>();
            try
            {
                var producto = await _productoRepository.GetById(id);

                if (producto != null)
                {
                    if (validateDto(productoDto))
                    {
                        await _productoRepository.Update(producto);
                        response.data = productoDto;
                    }
                    response.SetError("Faltan ingresar datos del producto", HttpStatusCode.BadRequest);
                }
                response.SetError("Producto no encontrado", HttpStatusCode.NotFound);
                
            } catch (Exception e)
            {
                response.SetError(e.Message, HttpStatusCode.InternalServerError);
            }
            return response;
        }
    }
}
