namespace Core;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int  Price { get; set; }
    
    public Service(int id, string name, int price = 0, string description = "")
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
    }
}