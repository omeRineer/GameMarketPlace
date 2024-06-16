using CMS.Services.Base;
using Entities.Main;
using RestSharp;

namespace CMS.Services.Master
{
    public class GameService : BaseService<Game>
    {
        public async Task<RestResponse> AddAsync(Game game)
            => await AddAsync("/games/add", game);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("/games/delete", id);

        public async Task<RestResponse> UpdateAsync(Game game)
            => await UpdateAsync("/games/update", game);
    }
}
