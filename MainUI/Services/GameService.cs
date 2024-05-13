using Configuration;
using Core.Utilities.RestHelper;
using UserInterface.Model.Game;

namespace MainUI.Services
{
    public class GameService
    {

        public async Task<List<GetGameViewModel>> GetGames()
        {
            var result = await RestHelper.GetAsync<List<GetGameViewModel>>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.APIOptions.WebAPI.BaseUrl}/Games/GetGames"
            });

            return result.Data;
        }
    }
}
