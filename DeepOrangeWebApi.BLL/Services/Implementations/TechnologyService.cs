using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;
using AutoMapper;
using DeepOrangeWebApi.BLL.Models.DTOs;

namespace DeepOrangeWebApi.BLL.Services.Implementations;

public class TechnologyService : ITechnologyService
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;

    public TechnologyService(ITechnologyRepository technologyRepository, IMapper mapper)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(int directionId, TechnologyCreateDto technology)
    {
        await _technologyRepository.AddAsync(directionId, _mapper.Map<Technology>(technology));
    }

    public async Task<TechnologyReadDto> GetByIdAsync(int directionId, int technologyId)
    {
        var technology = _technologyRepository.GetByIdAsync(directionId, technologyId);

        return _mapper.Map<TechnologyReadDto>(technology);
    }

    public async Task<IEnumerable<TechnologyReadDto>> GetTechnologiesForDirection(int directionId)
    {
        var technologies = _technologyRepository.GetTechnologiesForDirection(directionId);

        return _mapper.Map<IEnumerable<TechnologyReadDto>>(technologies);
    }

    public async Task UpdateAsync(int directionId, TechnologyCreateDto technology)
    {
        await _technologyRepository.UpdateAsync(directionId, _mapper.Map<Technology>(technology));
    }

    public async Task DeleteAsync(int directionId, int technologyId)
    {
        await _technologyRepository.DeleteAsync(directionId, technologyId);
    }
}