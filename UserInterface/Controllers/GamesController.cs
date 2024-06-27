using AutoMapper;
using Business.Services.Abstract;
using Configuration;
using Core.Utilities.ResultTool;
using Entities.Enum.Type;
using Entities.Main;
using Entities.Models.Game.ViewModels;
using Entities.Models.Media.ViewModels;
using MeArch.Module.Email.Model.Enums;
using MeArch.Module.Email.Service;
using MeArch.Module.Security.Model.Dto;
using MeArch.Module.Security.Model.UserIdentity;
using MeArch.Module.Templates;
using MeArch.Module.Templates.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MimeKit;
using UserInterface.Models.Game;

namespace UserInterface.Controllers
{
    public static class UserGames
    {
        public static List<Game> Games = new List<Game>();
    }
    public class GamesController : Controller
    {
        readonly IGameService _gameService;
        readonly IMemoryCache _memoryCache;
        readonly IMediaService _mediaService;
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;
        readonly IEmailService _emailService;
        readonly CurrentUser CurrentUser;

        public GamesController(IGameService gameService, IMediaService mediaService, IMapper mapper, CurrentUser currentUser, ICategoryService categoryService, IMemoryCache memoryCache, IEmailService emailService)
        {
            _gameService = gameService;
            _mediaService = mediaService;
            _mapper = mapper;
            CurrentUser = currentUser;
            _categoryService = categoryService;
            _memoryCache = memoryCache;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetListAsync();
            var trendGames = await _gameService.GetListAsync();
            var medias = await _mediaService.GetMediaListByEntites(trendGames.Data.Select(s => s.Id).ToList());

            ViewBag.Categories = categories.Data;
            var result = trendGames.Data.Select(s => new GameListViewModel
            {
                Id = s.Id,
                CategoryId = s.CategoryId,
                CategoryName = s.Category.Name,
                Name = s.Name,
                Price = s.Price,
                CoverPath = medias.Data.FirstOrDefault(f => f.EntityId.Equals(s.Id) && f.MediaTypeId == (int)MediaTypeEnum.GameCoverImage)?.MediaPath
            }).ToList();

            return View(result);
        }

        public async Task<IActionResult> GetDetail([FromRoute] Guid id)
        {
            var game = (await _gameService.GetByIdAsync(id)).Data;
            var gameViewModel = _mapper.Map<GameDetailViewModel>(game);

            var gameMedias = await _mediaService.GetMediaListByEntityId(id);

            gameViewModel.GameMedias = gameMedias.Data.Where(f => f.MediaTypeId == (int)MediaTypeEnum.GameImage).Select(s => new MediaViewModel
            {
                EntityId = s.EntityId,
                MediaPath = s.MediaPath,
                MediaType = s.MediaType.Description,
                MediaTypeId = s.MediaTypeId
            }).ToList();


            return View(gameViewModel);
        }

        [Authorize]
        public async Task Buy([FromBody] Guid gameId)
        {
            var game = (await _gameService.GetByIdAsync(gameId)).Data;
            UserGames.Games.Add(game);

            _memoryCache.Set("UserGames", UserGames.Games);

            await _emailService.SendAsync(new MeArch.Module.Email.Model.MailMessage
            {
                Subject = "Fatura Maili",
                Body = await RazorEngine.CompileRenderAsync(Template.Email.GameInvoiceTemplate, new { Name = CurrentUser.Name, Game = game.Name, Price = game.Price}),
                BodyType = MailBodyTypeEnum.HTML,
                From = new MailboxAddress(CoreConfiguration.EmailOptions.From, CoreConfiguration.EmailOptions.UserName),
                To = new List<MailboxAddress>
                    {
                        new MailboxAddress(CoreConfiguration.EmailOptions.From, CurrentUser.Email)
                    }
            });
        }
    }
}
