using DeepOrangeWebApi.DAL.Entities;

namespace DeepOrangeWebApi.BLL.Models.DTOs;

public class TechnologyReadDto
{
    public int TechnologyId { get; set; }
    public string TechnologyName { get; set; } = null!;
}
