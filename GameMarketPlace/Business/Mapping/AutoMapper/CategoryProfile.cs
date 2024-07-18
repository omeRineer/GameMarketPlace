using AutoMapper;
using Entities.Main;
using Models.Category.OData;

namespace Business.Mapping.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {

            #region View Models
            #endregion

            #region ODataModel
            CreateMap<Category, CategoryCreateODataModel>().ReverseMap();
            CreateMap<Category, CategoryUpdateODataModel>().ReverseMap();
            #endregion
        }
    }
}
