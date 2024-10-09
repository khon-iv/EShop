namespace Core;

public class Cart
{
    public List<CartLine> CartLines { get; set; } = new List<CartLine>();

    public string AddCartLine(Nomenclature nomenclature, int count = 1)
    {
        if (nomenclature.Type == NomenclatureTypes.Service)
            if (CartLines.Select(line => line.Id).ToList().Contains(nomenclature.Id))
                return "В корзине уже есть данная услуга";
            else
            {
                CartLines.Add(new CartLine(nomenclature, 1));
                return $"В корзину добавлена услуга {nomenclature.Name}";
            }
        
        if (count < 1)
        {
            return "Нельзя добавлять менее 1 товара в корзину";
        }
        
        var catalogItemCount = Catalog.CatalogItems.First(i => i.Id == nomenclature.Id).Remains;
        if (catalogItemCount < 1)
        {
            return "Товар закончился";
        }
        
        count = catalogItemCount < count ? catalogItemCount : count;
        if (CartLines.Select(x => x.Id).ToList().Contains(nomenclature.Id))
        {
            CartLines.First(line => line.Id == nomenclature.Id).Count += count;
            Catalog.CatalogItems.First(i => i.Id == nomenclature.Id).Remains -= count;
        }
        else
        {
            CartLines.Add(new CartLine(nomenclature, count));
        }
        
        return $"В корзину добавлен товар {nomenclature.Name} в количестве {count}";
    }
}