using AutoMapper;
using Turnit.GenericStore.Api.Entities;
using Turnit.GenericStore.Api.Models;

namespace Turnit.GenericStore.Api.Mappers
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreModel>();
        }
    }
}
