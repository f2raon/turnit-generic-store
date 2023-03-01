using AutoMapper;
using Turnit.GenericStore.Api.Entities;
using Turnit.GenericStore.Api.Models;

namespace Turnit.GenericStore.Api.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.Availability, opt => opt.MapFrom(e => e.ProductAvailablities))
                .ReverseMap();
        }
    }
}
