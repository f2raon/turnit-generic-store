using AutoMapper;
using Turnit.GenericStore.Api.Entities;
using Turnit.GenericStore.Api.Models;

namespace Turnit.GenericStore.Api.Mappers;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryModel>();
    }
}
