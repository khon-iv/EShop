namespace Core;

public static class Methods
{
    public static string AddItemToContainer(List<ItemLine> listOfItemLines, Nomenclature nomenclature, int count = 1)
    {
        if (nomenclature.Type == NomenclatureTypes.Service)
            if (listOfItemLines.Select(line => line.Id).ToList().Contains(nomenclature.Id))
                return "Данная услуга уже добавлена";
            else
            {
                listOfItemLines.Add(new ItemLine(nomenclature, 1));
                return $"Услуга {nomenclature.Name} добавлена";
            }
        
        if (count < 1)
            return "Нельзя добавлять менее 1 товара";
        
        var catalogItemCount = Catalog.CatalogItems.First(i => i.Id == nomenclature.Id).Remains;
        if (catalogItemCount < 1)
            return "Товар закончился";
        
        count = catalogItemCount < count ? catalogItemCount : count;
        if (listOfItemLines.Select(x => x.Id).ToList().Contains(nomenclature.Id))
        {
            listOfItemLines.First(line => line.Id == nomenclature.Id).Count += count;
            foreach (var catalogItem in Catalog.CatalogItems.Where(catalogItem => catalogItem.Nomenclature.Id == nomenclature.Id))
            {
                catalogItem.Remains -= count;
                break;
            }
        }
        else
        {
            listOfItemLines.Add(new ItemLine(nomenclature, count));
            foreach (var catalogItem in Catalog.CatalogItems.Where(catalogItem => catalogItem.Nomenclature.Id == nomenclature.Id))
            {
                catalogItem.Remains -= count;
                break;
            }
        }
        
        return $"Товар {nomenclature.Name} добавлен в количестве {count}";
    }
}