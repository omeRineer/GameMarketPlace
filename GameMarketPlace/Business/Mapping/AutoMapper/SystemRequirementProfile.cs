using AutoMapper;
using Entities.Dto.SystemRequirement;
using Entities.Main;
using Entities.Models.SystemRequirement.ViewModels;

namespace Business.Mapping.AutoMapper
{
    public class SystemRequirementProfile : Profile
    {
        public SystemRequirementProfile()
        {
            CreateMap<SystemRequirement, SystemRequirementAddDto>().ReverseMap();
            CreateMap<SystemRequirement, SystemRequirementEditDto>().ReverseMap();
            CreateMap<SystemRequirement, SystemRequirementDto>().ReverseMap();

            #region View Models
            CreateMap<SystemRequirement, SystemRequirementViewModel>().ReverseMap();
            #endregion
        }
    }
}
