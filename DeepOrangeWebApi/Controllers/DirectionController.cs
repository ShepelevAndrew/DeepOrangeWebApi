using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DeepOrangeWebApi.BLL.Services.Implementations;

namespace DeepOrangeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DirectionController : ControllerBase
    {
        private readonly IBaseService<Direction> _directionRepository;

        public DirectionController(IBaseService<Direction> directionRepository)
        {
            _directionRepository = directionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Direction direction)
        {
            await _directionRepository.CreateAsync(direction);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Direction>> Get()
        {
            var directions = await _directionRepository.GetAsync();
            return directions;
        }

        [HttpGet]
        public async Task<Direction> GetById(int id)
        {
            var direction = await _directionRepository.GetByIdAsync(id);
            return direction;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Direction direction)
        {
            await _directionRepository.UpdateAsync(direction);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _directionRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
