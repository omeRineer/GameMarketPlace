using AutoMapper;
using Entities.Main;
using Entities.Models.Category.ODataModels;
using Entities.Models.Category.Rest;
using Entities.Models.Category.ViewModels;

namespace Business.Mapping.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {


            #region View Models
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            #endregion

            #region ODataModel
            CreateMap<Category, CategoryCreateODataModel>().ReverseMap();
            CreateMap<Category, CategoryUpdateODataModel>().ReverseMap();
            #endregion
        }
    }
}
