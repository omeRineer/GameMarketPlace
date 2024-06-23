using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Main;
using Entities.Models.SliderContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface ISliderContentService : IEntityService<SliderContent, Guid>
    {
        Task<IResult> CreateSliderContentAsync(SliderContentCreateDto sliderContentCreateDto);
        Task<IDataResult<List<SliderContent>>> GetSliderContentByIsActive();
    }
}
