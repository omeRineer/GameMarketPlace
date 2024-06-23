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
    public interface IMediaService : IEntityService<Media, Guid>
    {
        Task<IResult> AddMediaListAsync(List<Media> mediaList);
        Task<IResult> UploadMedia(MediaUploadDto mediaUploadDto);
        Task<IDataResult<Media>> GetMediaByEntityId(Guid entityId);
        Task<IDataResult<List<Media>>> GetMediaListByEntityId(Guid entityId);
        Task<IDataResult<List<Media>>> GetMediaListByEntites(List<Guid> EntityIdList);
    }
}
