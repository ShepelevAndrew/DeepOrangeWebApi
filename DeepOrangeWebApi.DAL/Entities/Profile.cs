namespace DeepOrangeWebApi.DAL.Entities;

public class Profile
{
    public string? UserId { get; set; }
    public int ProfileId { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }

    public ICollection<Technology>? Technologies { get; set; }
}