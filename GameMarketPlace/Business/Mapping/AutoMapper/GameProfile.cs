using AutoMapper;
using Entities.Main;
using Entities.Models.Game.Rest;
using Entities.Models.Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            #region Backend
            CreateMap<Game, CreateGameRequest>().ReverseMap();
            #endregion

            #region View Models
            CreateMap<Game, GameDetailViewModel>().ReverseMap();
            #endregion
        }
    }
}
