namespace DeepOrangeWebApi.DAL.Entities;

public class Technology
{
    public int TechnologyId { get; set; }
    public string TechnologyName { get; set; } = null!;

    public int DirectionId { get; set; }
    public Direction? Direction { get; set; }
    public ICollection<Profile>? Profiles { get; set; }
}
