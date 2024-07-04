using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Enum.Type;
using Entities.Main;
using Entities.Models.Media.Rest;
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
        Task<IDataResult<List<Media>>> GetListByEntityAsync(Guid entityId, MediaTypeEnum? mediaType = null);
        Task<IDataResult<List<Media>>> GetListByMediaTypeAsync(MediaTypeEnum mediaType);
        Task<IResult> UploadMediaCollectionAsync(UploadMediaCollectionRequest request);
    }
}
