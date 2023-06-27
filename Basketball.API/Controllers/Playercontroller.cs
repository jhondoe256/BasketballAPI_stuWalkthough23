using Basketball.Models.EntityModels.PlayerModels;
using Basketball.Services.PlayerServices;
using Microsoft.AspNetCore.Mvc;

namespace Basketball.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Playercontroller : ControllerBase
    {
        private readonly IPlayerServiceNameTeam _playerService;

        public Playercontroller(IPlayerServiceNameTeam playerService)
        {
            _playerService = playerService;
        }

         [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _playerService.GetPlayers());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _playerService.GetPlayer(id);
            if (team is null) return NotFound();
            else
            {
                return Ok(team);
            }
        }

        [HttpGet]
       [Route("/GetPlayersAndTeam")]
        public async Task<IActionResult> GetPlayersAndTeam()
        {
            var team = await _playerService.GetPlayersAndTeam();
            if (team is null) return NotFound();
            else
            {
                return Ok(team);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlayerCreateVM model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            if (await _playerService.AddPlayer(model))
                return Ok("Player Created");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, PlayerUpdateVM model)
        {
            if (id != model.Id)
                return BadRequest("Invalid Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _playerService.UpdatePlayer(model))
                return Ok("Player Updated!");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id");

            if (await _playerService.DeletePlayer(id))
                return Ok("Player Deleted!");
            else
                return StatusCode(500, "Internal Server Error.");
        }
    }
}