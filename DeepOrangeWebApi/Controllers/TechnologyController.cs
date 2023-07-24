using DeepOrangeWebApi.BLL.Models.DTOs;
using DeepOrangeWebApi.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeepOrangeWebApi.Controllers
{
    [ApiController]
    [Route("api/v1.0/directions/{directionId}/technologies")]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService _technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int directionId, [FromBody] TechnologyCreateDto technology)
        {
            await _technologyService.CreateAsync(directionId, technology);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<TechnologyReadDto>> GetTechnologiesForDirection(int directionId)
        {
            var technologies = await _technologyService.GetTechnologiesForDirection(directionId);
            return technologies;
        }

        [HttpGet("{id}", Name = "Id")]
        public async Task<TechnologyReadDto> Id(int directionId, int id)
        {
            var technology = await _technologyService.GetByIdAsync(directionId, id);
            return technology;
        }

        [HttpPut]
        public async Task<IActionResult> Update(int directionId, [FromBody] TechnologyCreateDto technology)
        {
            await _technologyService.UpdateAsync(directionId, technology);
            return Ok();
        }

        [HttpDelete("{id}", Name = "Delete")]
        public async Task<IActionResult> Delete(int directionId, int id)
        {
            await _technologyService.DeleteAsync(directionId, id);
            return Ok();
        }
    }
}
