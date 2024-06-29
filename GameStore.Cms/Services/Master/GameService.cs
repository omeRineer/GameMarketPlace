using GameStore.Cms.Model.Game;
using GameStore.Cms.Model.Media;
using GameStore.Cms.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Enum.Type;
using Entities.Main;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class GameService : BaseService<Game>
    {
        public async Task<RestResponse> UploadGameImagesAsync(UploadGameImagesModel uploadGameImagesModel)
            => await RestHelper.PostAsync<UploadGameImagesModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/games/uploadgameimages",
                QueryParameters = new Dictionary<string, object> { { "EntityId", uploadGameImagesModel.EntityId } },
                Files = uploadGameImagesModel.Images.Select(s => new RestFile
                {
                    Bytes = s.Bytes,
                    FileName = s.FileName,
                    Name = s.FileName
                }).ToList()
            });

        public async Task<RestResponse> CreateGameAsync(CreateGameModel createGameModel)
            => await RestHelper.PostAsync<CreateGameModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/games/creategame"
            }, createGameModel);

        public async Task<RestResponse> AddAsync(Game game)
            => await AddAsync("/games/add", game);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("/games/delete", id);

        public async Task<RestResponse> UpdateAsync(Game game)
            => await UpdateAsync("/games/update", game);
    }
}
