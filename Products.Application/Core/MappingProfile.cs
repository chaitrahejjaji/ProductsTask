using AutoMapper;
using Products.Application.Products.Dtos;
using Products.Domain.Entities;

namespace Products.Application.Core
{
    /// <summary>
    /// Mapping profile used by AutoMapper
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}