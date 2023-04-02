using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeepOrangeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TechnologyController : ControllerBase
    {
        private readonly IBaseService<Technology> _technologyRepository;

        public TechnologyController(IBaseService<Technology> technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Technology technology)
        {
            await _technologyRepository.CreateAsync(technology);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Technology>> Get()
        {
            var technologys = await _technologyRepository.GetAsync();
            return technologys;
        }

        [HttpGet]
        public async Task<Technology> GetById(int id)
        {
            var technology = await _technologyRepository.GetByIdAsync(id);
            return technology;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Technology technology)
        {
            await _technologyRepository.UpdateAsync(technology);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _technologyRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
