using AutoMapper;
using DeepOrangeWebApi.BLL.Models.DTOs;
using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;

namespace DeepOrangeWebApi.BLL.Services.Implementations;

public class ProfileService : IServiceBase<ProfileCreateDto, ProfileReadDto>
{
    private readonly IBaseRepository<DAL.Entities.Profile> _profileRepository;
    private readonly IMapper _mapper;

	public ProfileService(IBaseRepository<DAL.Entities.Profile> profileRepository, IMapper mapper)
	{
		_profileRepository = profileRepository;
        _mapper = mapper;
	}

    public async Task CreateAsync(ProfileCreateDto profile)
    {
        await _profileRepository.AddAsync(_mapper.Map<DAL.Entities.Profile>(profile));
    }

    public async Task<IEnumerable<ProfileReadDto>> GetAsync()
	{
		var profiles = await _profileRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<ProfileReadDto>>(profiles);
    }

    public async Task<ProfileReadDto> GetByIdAsync(int id)
    {
        var profile = await _profileRepository.GetByIdAsync(id);

        return _mapper.Map<ProfileReadDto>(profile);
    }

    public async Task UpdateAsync(ProfileCreateDto profile)
    {
        await _profileRepository.UpdateAsync(_mapper.Map<DAL.Entities.Profile>(profile));
    }

    public async Task DeleteAsync(int id)
    {
        await _profileRepository.DeleteAsync(id);
    }
}
