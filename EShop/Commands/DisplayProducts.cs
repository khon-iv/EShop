using Core;

namespace EShop.Commands;

public static class DisplayProducts
{
    public const string Name = "DisplayProducts";
    public const string Description = "показать товары";
    
    public static void Execute(int productCountForDisplay = -1)
    {
        if ((productCountForDisplay < 0 ) || (productCountForDisplay > ProductCatalog.ProductsForDisplay.Count))
            productCountForDisplay = ProductCatalog.ProductsForDisplay.Count;
        for (var i = 0; i < productCountForDisplay; i++)
        {
            Console.WriteLine(
                ProductCatalog.ProductsForDisplay[i].Name + "\n" +
                "Цена: " + ProductCatalog.ProductsForDisplay[i].Price + "\n" +
                "Остаток: " + ProductCatalog.ProductsForDisplay[i].Remains
            );
            if (ProductCatalog.ProductsForDisplay[i].Description != String.Empty)
                Console.WriteLine("Описание: " + ProductCatalog.ProductsForDisplay[i].Description);
            Console.WriteLine();
        }
    }

}