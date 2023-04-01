namespace DeepOrangeWebApi.DAL.Entities;
public class Technology
{
    public int TechnologyId { get; set; }
    public string TechnologyName { get; set; }

    public int DirectionId { get; set; }
    public Direction Direction { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
