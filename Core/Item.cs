namespace Core;

public class Item
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public ItemTypes Type { get; }
    public string Description { get; }
    
    public Item(int id, string name, decimal price, ItemTypes itemType, string description = "")
    {
        Id = id;
        Name = name;
        Price = price;
        Type = itemType;
        Description = description;
    }
}