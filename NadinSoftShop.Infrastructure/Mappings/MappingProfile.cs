using AutoMapper;
using NadinSoftShop.Domain.Product.Dtos;
using NadinSoftShop.Domain.Product.Entities;

namespace NadinSoftShop.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
        }
    }
}
