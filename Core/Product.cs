namespace Core;

public class Product
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public ProductCategories Category { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Remains { get; set; }
    
    public Product(int id, string name, ProductCategories category, int price = 0, int remains = 1, string description = "")
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        Remains = remains;
        Description = description;
    }
}