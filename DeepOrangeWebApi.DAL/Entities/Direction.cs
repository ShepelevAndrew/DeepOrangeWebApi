namespace DeepOrangeWebApi.DAL.Entities;
public class  Direction
{
    public int DirectionId { get; set; }
    public string DirectionName { get; set; } = null!;

    public List<Technology>? Technologies { get; set; }
}
