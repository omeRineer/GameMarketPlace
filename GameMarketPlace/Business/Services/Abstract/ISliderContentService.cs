using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Main;
using Models.SliderContent.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface ISliderContentService
    {
        Task<IResult> CreateAsync(CreateSliderContentRequest request);
        Task<IResult> UpdateAsync(UpdateSliderContentRequest request);
        Task<IResult> DeleteAsync(Guid id);
    }
}
