using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDotNetCore9.DataBase;

namespace WebApiDotNetCore9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly VideoGameDbContext _context ;
        public VideoGameController(VideoGameDbContext context)
        {
            _context = context;
        }
        //static private List<VideoGamecs> videoGames = new List<VideoGamecs>
        //{
        //    new VideoGamecs { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", Publisher = "Nintendo" },
        //    new VideoGamecs { Id = 2, Title = "The Witcher 3: Wild Hunt", Platform = "PC", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
        //    new VideoGamecs { Id = 3, Title = "Dark Souls III", Platform = "PC", Developer = "FromSoftware", Publisher = "Bandai Namco Entertainment" }
        //};

        [HttpGet]
        [Route("GetAllVideoGame")]
        public async Task<ActionResult<List<VideoGamecs>>> GetAllVideoGame()
        {
            var result = await _context.VideoGames.ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetVideoGameById")]
        public async Task<ActionResult<VideoGamecs>> GetVideoGameById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
                return NotFound();

            await _context.VideoGames.FindAsync(id);
            return Ok(game);
        }
        [HttpPost]
        [Route("CreateNewGame")]
        public async Task<ActionResult<VideoGamecs>> CreateNewGame(VideoGamecs newGame)
        {
            if (newGame == null)
                return BadRequest();

            await _context.VideoGames.AddAsync(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGameById),new {id = newGame.Id},newGame);
        }
        [HttpPut]
        [Route("UpdateGame")]
        public async Task<IActionResult> UpdateGame(int id, VideoGamecs updatedGame)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
                return NotFound();
            game.Title = updatedGame.Title;
            game.Platform = updatedGame.Platform;
            game.Developer = updatedGame.Developer;
            game.Publisher = updatedGame.Publisher;
           _context.VideoGames.Update(game);
            await _context.SaveChangesAsync();
            return Ok(game);
        }
        [HttpDelete]
        [Route("DeleteGame")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
                return NotFound();
            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return Ok(game);

        }
    }
}
