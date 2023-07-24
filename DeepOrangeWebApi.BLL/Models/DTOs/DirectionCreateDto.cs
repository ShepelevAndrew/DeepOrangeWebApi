namespace DeepOrangeWebApi.BLL.Models.DTOs;

public class DirectionCreateDto
{
    public string DirectionName { get; set; } = null!;

    public List<TechnologyCreateDto>? Technologies { get; set; }
}
