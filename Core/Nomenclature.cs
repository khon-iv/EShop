namespace Core;

public class Nomenclature(
    int id,
    string name,
    decimal price,
    NomenclatureTypes nomenclatureType,
    string description = "")
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public decimal Price { get; } = price;
    public NomenclatureTypes Type { get; } = nomenclatureType;
    public string Description { get; } = description;
}