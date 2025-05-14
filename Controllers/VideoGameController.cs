using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDotNetCore9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGamecs> videoGames = new List<VideoGamecs>
        {
            new VideoGamecs { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", Publisher = "Nintendo" },
            new VideoGamecs { Id = 2, Title = "The Witcher 3: Wild Hunt", Platform = "PC", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
            new VideoGamecs { Id = 3, Title = "Dark Souls III", Platform = "PC", Developer = "FromSoftware", Publisher = "Bandai Namco Entertainment" }
        };

        [HttpGet]
        [Route("GetAllVideoGame")]
        public ActionResult<List<VideoGamecs>> GetAllVideoGame()
        {
            return Ok(videoGames);
        }
        [HttpGet]
        [Route("GetVideoGameById")]
        public ActionResult<VideoGamecs> GetVideoGameById(int id)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
            return Ok(game);
        }
        [HttpPost]
        [Route("CreateNewGame")]
        public ActionResult<VideoGamecs> CreateNewGame(VideoGamecs newGame)
        {
            if (newGame == null)
                return BadRequest();
            newGame.Id = videoGames.Max(g => g.Id) + 1;
            videoGames.Add(newGame);
            return CreatedAtAction(nameof(GetVideoGameById),new {id = newGame.Id},newGame);
        }
        [HttpPut]
        [Route("UpdateGame")]
        public IActionResult UpdateGame(int id, VideoGamecs updatedGame)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
            if (game == null)
                return NotFound();
            game.Title = updatedGame.Title;
            game.Platform = updatedGame.Platform;
            game.Developer = updatedGame.Developer;
            game.Publisher = updatedGame.Publisher;
            return NoContent();
        }
        [HttpDelete]
        [Route("DeleteGame")]
        public IActionResult DeleteGame(int id)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
            if (game == null)
                return NotFound();
            videoGames.Remove(game);
            return Ok(game);

        }
    }
}
