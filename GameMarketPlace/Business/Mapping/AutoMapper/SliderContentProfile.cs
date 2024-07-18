using AutoMapper;
using Entities.Main;
using Models.SliderContent.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class SliderContentProfile : Profile
    {
        public SliderContentProfile()
        {
            CreateMap<SliderContent, CreateSliderContentRequest>().ReverseMap();
        }
    }
}
