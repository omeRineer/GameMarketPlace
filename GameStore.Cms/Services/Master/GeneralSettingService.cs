﻿using Entities.Main;
using GameStore.Cms.Services.Base;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class GeneralSettingService : BaseService
    {
        public GeneralSettingService() : base("GeneralSettings") { }

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync(id);
    }
}