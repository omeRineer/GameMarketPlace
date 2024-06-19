using CMS.Model.Media;
using CMS.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Enum.Type;
using Entities.Main;
using RestSharp;

namespace CMS.Services.Master
{
    public class MediaService : BaseService<Media>
    {
        public async Task<RestResponse> UploadMedia(MediaUploadModel mediaUploadModel)
            => await RestHelper.PostAsync<object, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/medias/uploadmedia",
                QueryParameters = new Dictionary<string, object> { { "EntityId", mediaUploadModel.EntityId }, { "MediaTypeId", (int)MediaTypeEnum.GameImage } },
                Files = mediaUploadModel.MediaList.Select(s => new RestFile
                {
                    Bytes = s.Bytes,
                    FileName = s.FileName,
                    Name = s.FileName
                }).ToList()
            });
    }
}
