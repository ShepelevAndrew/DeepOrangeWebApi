namespace DeepOrangeWebApi.BLL.Models.DTOs;

public class DirectionReadDto
{
    public int DirectionId { get; set; }
    public string DirectionName { get; set; } = null!;

    public List<TechnologyReadDto>? Technologies { get; set; }
}
