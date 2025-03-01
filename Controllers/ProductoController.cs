using Desafio_tecnico.Data;
using Desafio_tecnico.DTO;
using Desafio_tecnico.Models;
using Desafio_tecnico.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_tecnico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IProductoService _productoService;

        public ProductoController(ContextDb context, IProductoService productoService)
        {
            _context = context;
            _productoService = productoService;
        }

        /*
        Endpoint que obtendra una lista de productos
        
        METHOD: GET

        URL: /producto/producto/getAll

        RESPONSE: 
        [
            {
                "id": 1,
                "name": "Producto 1",
                "description": "Descripcion del producto 1",
                "price": 1000,
                "quantity": 10
            },
            {
                "id": 2,
                "name": "Producto 2",
                "description": "Descripcion del producto 2",
                "price": 2000,
                "quantity": 25
            }
        ]

        Return:
            - 200: Si se obtiene la lista de productos
            - 404: Si no se encuentran productos cargados
            - 500: Si ocurre un error en el servidor

        */

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productoService.GetAll();
            return Ok(response);
        }

        /*
        Endpoint que obtendra un producto por id

        METHOD: GET

        URL: /producto/producto/getById/{id}

        RESPONSE:
        {
            "id": 1,
            "name": "Producto 1",
            "description": "Descripcion del producto 1",
            "price": 1000,
            "quantity": 10
        }

        Return:
            - 200: Si se obtiene el producto
            - 404: Si no se encuentra el producto
            - 422: Si el id no es valido
            - 500: Si ocurre un error en el servidor
         
        */
        
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetById(id);
            return Ok(producto);
        }

        /*
        Endpoint que inserta un nuevo producto en la base de datos
        
        METHOD: POST

        URL: /producto/producto/create

        Body:
        {
            "name": "Producto 1",
            "desctription": "Descripcion del producto 1",
            "price": 1000,
            "quantity": 10
        }

        Return:
            - 200: Si se inserta el producto
            - 400: Si los datos no son validos
            - 500: Si ocurre un error en el servidor
        */

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProductoDto producto)
        {
            var response = await _productoService.Create(producto);
            return Ok(response);
        }

        /*
        Endpoint que modificara los datos del producto seleccionado por id
        
        METHOD: PUT

        URL: /producto/producto/update/{id}

        RESPONSE:
        {
            "id": 1,
            "name": "Producto 1",
            "description": "Descripcion del producto 1",
            "price": 1000,
            "quantity": 10
        }

        Return:
            - 200: Si se actualiza el producto
            - 400: Si los datos no son validos
            - 500: Si ocurre un error en el servidor
        */

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductoDto producto)
        {

            var response = await _productoService.Update(id, producto);
            return Ok(response);
        }

        /*
        Endpoint que eliminara el producto seleccionado por id

        METHOD: DELETE

        URL: /producto/producto/delete/{id}

        RESPONSE:
        {
            "success": true
            "message": "Producto eliminado"
        }

        return:
            - 200: Si se elimina el producto
            - 404: Si no se encuentra el producto
            - 500: Si ocurre un error en el servidor
        */ 
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productoService.Delete(id);
            return Ok(response);
        }
    }
}
