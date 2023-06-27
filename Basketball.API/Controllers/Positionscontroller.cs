using Basketball.Models.EntityModels.PositionModels;
using Basketball.Services.PositionServices;
using Microsoft.AspNetCore.Mvc;

namespace Basketball.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Positionscontroller : ControllerBase
    {
        private readonly IPositionService _posService;

        public Positionscontroller(IPositionService posService)
        {
            _posService = posService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _posService.GetPositions());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _posService.GetPosition(id);
            if (team is null) return NotFound();
            else
            {
                return Ok(team);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PositionCreateVM model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var pos = await _posService.AddPosition(model);
            if (pos is not null)
                return Ok(pos);
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, PositionUpdateVM model)
        {
            if (id != model.Id)
                return BadRequest("Invalid Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _posService.UpdatePosition(model))
                return Ok("Position Updated!");
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id");

            if (await _posService.DeletePosition(id))
                return Ok("Position Deleted!");
            else
                return StatusCode(500, "Internal Server Error.");
        }
    }
}