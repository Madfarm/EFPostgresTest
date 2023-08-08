namespace EFPostTest.Models;

public class Jacket
{
    public int Id { get; set; }
    public int? CollectionId { get; set; }
    public int Size { get; set; }
    public string? Material { get; set; }
    public int Price { get; set; }
}