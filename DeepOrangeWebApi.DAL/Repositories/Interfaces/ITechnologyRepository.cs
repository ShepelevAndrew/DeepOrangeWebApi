using DeepOrangeWebApi.DAL.Entities;

namespace DeepOrangeWebApi.DAL.Repositories.Interfaces;

public interface ITechnologyRepository
{
    Task AddAsync(int directionId, Technology technology);
    Technology GetByIdAsync(int directionId, int technologyId);
    IEnumerable<Technology> GetTechnologiesForDirection(int directionId);
    Task UpdateAsync(int directionId, Technology technology);
    Task DeleteAsync(int directionId, int technologyId);
}
