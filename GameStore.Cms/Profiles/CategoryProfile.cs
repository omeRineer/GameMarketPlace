using AutoMapper;
using Models.Category.Cms;

namespace GameStore.Cms.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<SingleCategoryModel, UpdateCategoryModel>().ReverseMap();
        }
    }
}
