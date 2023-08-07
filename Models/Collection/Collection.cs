namespace EFPostTest.Models;

public class Collection 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Jacket> Jackets { get; } = new List<Jacket>();
}