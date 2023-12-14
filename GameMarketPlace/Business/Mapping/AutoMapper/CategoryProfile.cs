using AutoMapper;
using Entities.Dto.Category;
using Entities.Main;

namespace Business.Mapping.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
