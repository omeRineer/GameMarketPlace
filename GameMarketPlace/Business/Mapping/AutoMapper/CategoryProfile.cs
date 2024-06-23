using AutoMapper;
using Entities.Dto.Category;
using Entities.Main;
using Entities.Models.Category.ViewModels;

namespace Business.Mapping.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();


            #region View Models
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            #endregion
        }
    }
}
