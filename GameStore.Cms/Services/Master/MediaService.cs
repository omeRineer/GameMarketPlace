using GameStore.Cms.Model.Media;
using GameStore.Cms.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Main;
using RestSharp;
using Entities.Enum.Type;

namespace GameStore.Cms.Services.Master
{
    public class MediaService : BaseService<Media>
    {
        public MediaService() : base("Medias") { }

        public async Task<RestResponse> UploadMedia(MediaUploadModel mediaUploadModel)
            => await RestHelper.PostAsync<object, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/uploadmedia",
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
