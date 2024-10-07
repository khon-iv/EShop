namespace Core;

public class Product
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public Categories Category { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Remains { get; set; }
    
    public Product(int id, string name, Categories category, int price = 0, int remains = 1, string description = "")
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        Remains = remains;
        Description = description;
    }

    public enum Categories
    {
        ForHome,
        ForBeautyAndHealth,
        Phone,
        TV,
        PC
    }
}