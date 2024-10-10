namespace Core;

public class Cart
{
    public List<ItemLine> CartLines { get; set; } = [];
    
    public decimal CartTotalPrice => CartLines.Select(line => line.ItemNomenclature.Price * line.Count).ToList().Sum();

    public string AddItemToCart(Nomenclature nomenclature, int count = 1)
    {
        return 
            $"Добавление в корзину {nomenclature.Name} в количестве {count}...\n" +
            $"{Methods.AddItemToContainer(CartLines, nomenclature, count)}";
    }
}