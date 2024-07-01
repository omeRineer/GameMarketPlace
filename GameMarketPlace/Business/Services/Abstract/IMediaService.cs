using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Dto.Media;
using Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IMediaService
    {
        Task<IResult> CreateAsync(Media media);
    }
}
