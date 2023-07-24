using DeepOrangeWebApi.DAL.EF;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeepOrangeWebApi.DAL.Repositories.Implementations;

public class ProfileRepository : IBaseRepository<Profile>
{
    private readonly DbContextApp _dbContextApp;

	public ProfileRepository(DbContextApp dbContextApp)
	{
        _dbContextApp = dbContextApp;
	}

    public async Task AddAsync(Profile profile)
    {
        _dbContextApp.Technologies.AttachRange(profile.Technologies);
        _dbContextApp.Profiles.Add(profile);
        await _dbContextApp.SaveChangesAsync();
    }

    public async Task<IEnumerable<Profile>> GetAllAsync()
    {
        var profiles = await _dbContextApp.Profiles.Include(p => p.Technologies).ToListAsync();

        return profiles;
    }

    public async Task<Profile> GetByIdAsync(int id)
    {
        var profile = await _dbContextApp.Profiles.Include(p => p.Technologies).FirstOrDefaultAsync(p => p.ProfileId == id);

        return profile;
    }

    public async Task UpdateAsync(Profile profile)
    {
        var existingProfile = _dbContextApp.Profiles.Include(p => p.Technologies)
        .SingleOrDefault(p => p.ProfileId == profile.ProfileId);

        if (existingProfile != null)
        {
            existingProfile.Name = profile.Name;
            existingProfile.LastName = profile.LastName;
            existingProfile.Technologies.Clear();

            if (profile.Technologies != null)
            {
                foreach (var tech in profile.Technologies)
                {
                    var existingTech = await _dbContextApp.Technologies.FirstOrDefaultAsync(t => t.TechnologyId == tech.TechnologyId);
                    if (existingTech != null)
                    {
                        existingProfile.Technologies.Add(existingTech);
                    }
                }
            }

            await _dbContextApp.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var profile = await _dbContextApp.Profiles.FindAsync(id);

        _dbContextApp.Profiles.Remove(profile);
        await _dbContextApp.SaveChangesAsync();
    }
}
