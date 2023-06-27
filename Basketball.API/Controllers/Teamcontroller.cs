using Basketball.Models.EntityModels.TeamModels;
using Basketball.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;

namespace Basketball.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Teamcontroller : ControllerBase
    {
        private readonly ITeamService _teamService;

        public Teamcontroller(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _teamService.GetTeams());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _teamService.GetTeam(id);
            if (team is null) return NotFound();
            else
            {
                return Ok(team);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TeamCreateVM model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            if (await _teamService.AddTeam(model))
                return Ok("Team Created");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, TeamUpdateVM model)
        {
            if (id != model.Id)
                return BadRequest("Invalid Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _teamService.UpdateTeam(model))
                return Ok("Team Updated!");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id");

            if (await _teamService.DeleteTeam(id))
                return Ok("Team Deleted!");
            else
                return StatusCode(500, "Internal Server Error.");
        }

    }
}