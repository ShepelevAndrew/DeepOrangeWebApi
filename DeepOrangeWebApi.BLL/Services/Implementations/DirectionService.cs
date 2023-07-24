using AutoMapper;
using DeepOrangeWebApi.BLL.Models.DTOs;
using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;

namespace DeepOrangeWebApi.BLL.Services.Implementations;

public class DirectionService : IServiceBase<DirectionCreateDto, DirectionReadDto>
{
    private readonly IBaseRepository<Direction> _directionRepository;
    private readonly IMapper _mapper;

    public DirectionService(IBaseRepository<Direction> directionRepository, IMapper mapper)
    {
        _directionRepository = directionRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(DirectionCreateDto direction)
    {
        await _directionRepository.AddAsync(_mapper.Map<Direction>(direction));
    }

    public async Task<IEnumerable<DirectionReadDto>> GetAsync()
    {
        var directions = await _directionRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DirectionReadDto>>(directions);
    }

    public async Task<DirectionReadDto> GetByIdAsync(int id)
    {
        var direction = await _directionRepository.GetByIdAsync(id);
        return _mapper.Map<DirectionReadDto>(direction);
    }

    public async Task UpdateAsync(DirectionCreateDto direction)
    {
        await _directionRepository.UpdateAsync(_mapper.Map<Direction>(direction));
    }

    public async Task DeleteAsync(int id)
    {
        await _directionRepository.DeleteAsync(id);
    }
}