using Configuration;
using Core.Utilities.RestHelper;
using GameStore.UI.Model.Game;

namespace GameStore.UI.Services
{
    public class GameService
    {

        public async Task<List<GetGameViewModel>> GetGames()
        {
            var result = await RestHelper.GetAsync<List<GetGameViewModel>>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.APIOptions.WebAPI.BaseUrl}/api/Games/GetGames"
            });

            return result.Data;
        }
    }
}
