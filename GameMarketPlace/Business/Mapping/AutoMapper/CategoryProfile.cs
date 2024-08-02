using AutoMapper;
using Entities.Main;
using Models.Category.OData;
using Models.Category.WebService;

namespace Business.Mapping.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            #region Web Service
            CreateMap<Category, SingleCategoryResponse>().ReverseMap();
            #endregion

            #region View Models
            #endregion

            #region ODataModel
            CreateMap<Category, CategoryCreateODataModel>().ReverseMap();
            CreateMap<Category, CategoryUpdateODataModel>().ReverseMap();
            #endregion
        }
    }
}
