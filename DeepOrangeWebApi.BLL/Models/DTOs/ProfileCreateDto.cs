namespace DeepOrangeWebApi.BLL.Models.DTOs;

public class ProfileCreateDto
{
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }

    public ICollection<TechnologyReadDto>? Technologies { get; set; }
}
