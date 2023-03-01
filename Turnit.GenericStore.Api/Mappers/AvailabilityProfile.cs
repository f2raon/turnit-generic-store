using AutoMapper;
using Turnit.GenericStore.Api.Entities;
using Turnit.GenericStore.Api.Models;

namespace Turnit.GenericStore.Api.Mappers
{
    public class AvailabilityProfile : Profile
    {
        public AvailabilityProfile()
        {
            CreateMap<ProductAvailability, AvailabilityModel>()
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.Store.Id))
                .ReverseMap();
        }
    }
}
