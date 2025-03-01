using AutoMapper;

namespace Desafio_tecnico.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Producto, DTO.ProductoDto>().ReverseMap();
        }
    }
}
