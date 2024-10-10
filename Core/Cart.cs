namespace Core;

/// <summary>
/// Корзина
/// </summary>
public class Cart
{
    /// <summary>
    /// Список линий корзины
    /// </summary>
    public List<ItemLine> CartLines { get; set; } = [];
    
    /// <summary>
    /// Итоговая стоимость корзины
    /// </summary>
    public decimal CartTotalPrice => CartLines.Select(line => line.ItemNomenclature.Price * line.Count).ToList().Sum();

    /// <summary>
    /// Добавить элемент в корзину
    /// </summary>
    public string AddItemToCart(Nomenclature nomenclature, int count = 1)
    {
        return 
            $"Добавление в корзину {nomenclature.Name} в количестве {count}...\n" +
            $"{Methods.AddItemsToContainer(CartLines, nomenclature, count)}";
    }
}