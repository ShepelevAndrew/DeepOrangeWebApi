namespace DeepOrangeWebApi.BLL.Models.DTOs;

public class ProfileReadDto
{
    public string? UserId { get; set; }
    public int ProfileId { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }

    public ICollection<TechnologyReadDto>? Technologies { get; set; }
}