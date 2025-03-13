using GameZone.Data;
using GameZone.Data.DataModels;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using System.Security.Policy;
using static GameZone.ComanConsts;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController(GameZoneDbContext dbContext) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await dbContext.Games.Where(g => g.IsDeleted == false).Select(g => new GameInfoViewModel() 
            {
                Id = g.Id,
                ImageUrl = g.ImageUrl,
                Genre = g.Genre.Name,
                Publisher = g.Publisher.UserName ?? string.Empty,
                ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnDataFormat),
                Title = g.Title,
            }).AsNoTracking().ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add() 
        {
            GameViewModel game = new GameViewModel();
            game.Genres = await dbContext.Genre.AsNoTracking().ToListAsync();

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameViewModel gameModel)
        {
            DateTime date;

            if (DateTime.TryParseExact(gameModel.ReleasedOn.Trim(), GameReleasedOnDataFormat, CultureInfo.CurrentCulture,DateTimeStyles.None, out date) == false)
            {
                ModelState.AddModelError(nameof(gameModel.ReleasedOn), "Error data");
            }

            if (ModelState.IsValid == false)
            {
                return View(gameModel);
            }

            Game game = new Game() 
            {
                Description = gameModel.Description,
                GenreId = gameModel.GenreId,
                ImageUrl = gameModel.ImageUrl,
                Title = gameModel.Title,
                ReleasedOn = date,
                PublisherId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty,

            };
            await dbContext.AddAsync(game);
            await dbContext.SaveChangesAsync();


            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> MyZone() 
        {
            var game = await dbContext.Games
                .Where(x => x.IsDeleted == false)
                .Where(x => x.GamersGames.Any(z => z.GamerId == (User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty)))
                .Select(x => new GameInfoViewModel()
                {
                    Genre = x.Genre.Name,
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Publisher = x.Publisher.ToString(),
                    ReleasedOn = x.ReleasedOn.ToString(GameReleasedOnDataFormat),
                    Title = x.Title,
                })
                .AsNoTracking()
                .ToListAsync();

            return View(game);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            Game? entity = await dbContext.Games
                .Where(X => X.Id == id && X.IsDeleted == false)
                .Include(x => x.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted) 
            {
                throw new ArgumentException("Invalid id");
            }

            if ((entity.GamersGames
                .Any(a => a.GamerId == (User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty))) == false)
            {
                entity.GamersGames.Add(new GamersGames()
                {
                    GameId = entity.Id,
                    GamerId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                });
            }

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            Game? entity = await dbContext.Games
                .Where(X => X.Id == id && X.IsDeleted == false)
                .Include(x => x.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }

            GamersGames? gamersGames = entity.GamersGames
                .FirstOrDefault(a => a.GamerId == (User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty));

            if (gamersGames != null)
            {
                entity.GamersGames.Remove(gamersGames);

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {

            var game = await dbContext.Games.Include(x => x.Genre).Where(x => x.Id == id && x.IsDeleted == false).Select(x => new GameViewModel()
            {
                Description = x.Description,
                GenreId = x.GenreId,
                ImageUrl = x.ImageUrl,
                ReleasedOn = x.ReleasedOn.ToString(GameReleasedOnDataFormat),
                Title = x.Title,

            }).AsNoTracking().FirstOrDefaultAsync();

            game.Genres = await dbContext.Genre.AsNoTracking().ToListAsync();

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameViewModel gameModel, int id)
        {
            DateTime date;

            if (DateTime.TryParseExact(gameModel.ReleasedOn.Trim(), GameReleasedOnDataFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out date) == false)
            {
                ModelState.AddModelError(nameof(gameModel.ReleasedOn), "Error data");
            }

            if (ModelState.IsValid == false)
            {
                return View(gameModel);
            }

            var game = await dbContext.Games.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync();
            
            game.Description = gameModel.Description;
            game.GenreId = gameModel.GenreId;
            game.ImageUrl = gameModel.ImageUrl;
            game.Title = gameModel.Title;
            game.ReleasedOn = date;
            game.PublisherId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            

            await dbContext.SaveChangesAsync();


            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var gameDetails = await dbContext.Games.Where(x => x.Id == id && x.IsDeleted == false).Select(x => new GameDetailsViewModel() 
            {
                Description = x.Description,
                Genre = x.Genre,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Publisher = x.Publisher.ToString(),
                Title = x.Title,
                ReleasedOn = x.ReleasedOn,
            }).AsNoTracking().FirstOrDefaultAsync();

            return View(gameDetails);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await dbContext.Games.Where(x => x.Id == id && x.IsDeleted == false).Select(x => new GameDeleteViewModel() 
            {
                Id = x.Id,
                Publisher =x.Publisher.ToString(),
                Title = x.Title,
            }).FirstOrDefaultAsync();

            return View(game);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            Game? game = await dbContext.Games.Where(x => x.Id == id).FirstOrDefaultAsync();
            game.IsDeleted = true;

            await dbContext.SaveChangesAsync();
            
           

            return RedirectToAction(nameof(All));

        }
    }
}
