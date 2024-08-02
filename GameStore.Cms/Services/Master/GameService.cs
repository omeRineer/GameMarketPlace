using GameStore.Cms.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Enum.Type;
using Entities.Main;
using RestSharp;
using Models.Game.Cms;
using Models.Blog.Cms;

namespace GameStore.Cms.Services.Master
{
    public class GameService : BaseService
    {
        public GameService() : base("Games") { }

        public async Task<RestResponse> UploadGameImagesAsync(UploadGameImagesModel uploadGameImagesModel)
            => await RestHelper.PostAsync<UploadGameImagesModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/uploadgameimages",
                QueryParameters = new Dictionary<string, object> { { "EntityId", uploadGameImagesModel.EntityId } },
                Files = uploadGameImagesModel.Images.Select(s => new RestFile
                {
                    Bytes = s.Bytes,
                    FileName = s.FileName,
                    Name = s.FileName
                }).ToList()
            });

        public async Task<RestResponse<SingleBlogModel>> GetAsync(Guid id)
            => await GetAsync<Guid, SingleBlogModel>(id);

        public async Task<RestResponse> CreateAsync(CreateGameModel model)
            => await CreateAsync(model);

        public async Task<RestResponse> UpdateAsync(UpdateGameModel model)
            => await UpdateAsync(model);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync(id);
    }
}
