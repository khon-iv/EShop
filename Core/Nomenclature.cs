namespace Core;

public class Nomenclature
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public NomenclatureTypes Type { get; }
    public string Description { get; }
    
    public Nomenclature(int id, string name, decimal price, NomenclatureTypes nomenclatureType, string description = "")
    {
        Id = id;
        Name = name;
        Price = price;
        Type = nomenclatureType;
        Description = description;
    }
}