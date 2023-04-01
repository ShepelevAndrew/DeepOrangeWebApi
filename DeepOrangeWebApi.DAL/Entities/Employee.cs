namespace DeepOrangeWebApi.DAL.Entities;
public class Employee
{
    public int EmployeeId { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }

    public ICollection<Technology> Technologies { get; set; }
}