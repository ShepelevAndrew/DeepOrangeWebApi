using DeepOrangeWebApi.BLL.Models.DTOs;

namespace DeepOrangeWebApi.BLL.Services.Interfaces;

public interface ITechnologyService
{
    Task CreateAsync(int directionId, TechnologyCreateDto technology);
    Task<TechnologyReadDto> GetByIdAsync(int direcitonId, int technologyId);
    Task UpdateAsync(int directionId, TechnologyCreateDto technology);
    Task DeleteAsync(int directionId, int technologyId);
    Task<IEnumerable<TechnologyReadDto>> GetTechnologiesForDirection(int directionId);
}