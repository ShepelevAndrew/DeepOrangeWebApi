using DeepOrangeWebApi.BLL.Models.DTOs;
using DeepOrangeWebApi.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeepOrangeWebApi.Controllers
{
    [ApiController]
    [Route("api/v1.0/profiles")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IServiceBase<ProfileCreateDto, ProfileReadDto> _profileService;

        public ProfileController(ILogger<ProfileController> logger, IServiceBase<ProfileCreateDto, ProfileReadDto> profileService)
        {
            _logger = logger;
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProfileCreateDto profile)
        {
            await _profileService.CreateAsync(profile);
            return Ok();
        }

        [HttpGet]
        [Authorize(Policy = "Employee")]
        public async Task<IEnumerable<ProfileReadDto>> Get()
        {
            var profiles = await _profileService.GetAsync();
            return profiles;
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ProfileReadDto> GetById(int id)
        {
            var profile = await _profileService.GetByIdAsync(id);
            return profile;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProfileCreateDto employee)
        {
            await _profileService.UpdateAsync(employee);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _profileService.DeleteAsync(id);
            return Ok();
        }
    }
}