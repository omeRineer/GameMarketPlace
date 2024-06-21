using AutoMapper;
using Entities.Dto.Game;
using Entities.Main;
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
            CreateMap<Game, GameAddDto>().ReverseMap();
            CreateMap<Game, GameEditDto>().ReverseMap();
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<Game, CreateGameDto>().ReverseMap();
        }
    }
}
