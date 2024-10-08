namespace Core;

public class Cart
{
    public List<CartLine> CartLines { get; set; } = new List<CartLine>();

    public string AddCartLine(Item item, int count = 1)
    {
        if (item.Type == ItemTypes.Service)
            if (CartLines.Select(line => line.Id).ToList().Contains(item.Id))
                return "В корзине уже есть данная услуга";
            else
            {
                CartLines.Add(new CartLine(item, 1));
                return $"В корзину добавлена услуга {item.Name}";
            }
        
        if (count < 1)
        {
            return "Нельзя добавлять менее 1 товара в корзину";
        }
        
        var catalogItemCount = Catalog.CatalogItems.First(i => i.Id == item.Id).Remains;
        if (catalogItemCount < 1)
        {
            return "Товар закончился";
        }
        
        count = catalogItemCount < count ? catalogItemCount : count;
        if (CartLines.Select(x => x.Id).ToList().Contains(item.Id))
        {
            CartLines.First(line => line.Id == item.Id).Count += count;
            Catalog.CatalogItems.First(i => i.Id == item.Id).Remains -= count;
        }
        else
        {
            CartLines.Add(new CartLine(item, count));
        }
        
        return $"В корзину добавлен товар {item.Name} в количестве {count}";
    }
}