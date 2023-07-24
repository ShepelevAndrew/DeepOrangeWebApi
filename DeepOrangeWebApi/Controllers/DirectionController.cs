using DeepOrangeWebApi.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DeepOrangeWebApi.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using DeepOrangeWebApi.BLL.Models.DTOs;

namespace DeepOrangeWebApi.Controllers
{
    [ApiController]
    [Route("api/v1.0/directions")]
    public class DirectionController : ControllerBase
    {
        private readonly IServiceBase<DirectionCreateDto, DirectionReadDto> _directionRepository;

        public DirectionController(IServiceBase<DirectionCreateDto, DirectionReadDto> directionRepository)
        {
            _directionRepository = directionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DirectionCreateDto direction)
        {
            await _directionRepository.CreateAsync(direction);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<DirectionReadDto>> Get()
        {
            var directions = await _directionRepository.GetAsync();
            return directions;
        }

        [HttpGet("{id}")]
        public async Task<DirectionReadDto> Id(int id)
        {
            var direction = await _directionRepository.GetByIdAsync(id);
            return direction;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DirectionCreateDto direction)
        {
            await _directionRepository.UpdateAsync(direction);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _directionRepository.DeleteAsync(id);
            return Ok();
        }
    }
}