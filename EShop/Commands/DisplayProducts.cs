using System;
using System.Linq;
using Core;

namespace EShop.Commands;

public static class DisplayProducts
{
    public const string Name = "DisplayProducts";
    public const string Description = "показать товары";
    
    public static void Execute(string[]? args)
    {
        int productCountForDisplay = 0;
        if (args is null || args.Length == 0)
            productCountForDisplay = ProductCatalog.ProductsForDisplay.Count();
        else if (args.Length == 1)
            if (int.TryParse(args[0], out var number))
                productCountForDisplay = number;
            else
            {
                Console.WriteLine($"Для команды {Name} в качестве аргуимента может быть только число - количество товаров");
                return;
            }
        if ((productCountForDisplay < 1 ) || (productCountForDisplay > ProductCatalog.ProductsForDisplay.Count()))
            productCountForDisplay = ProductCatalog.ProductsForDisplay.Count();
        foreach (var product in ProductCatalog.ProductsForDisplay)
        {
            Console.WriteLine(
                product.Name + "\n" +
                "Цена: " + product.Price + "\n" +
                "Остаток: " + product.Remains
                );
            if (product.Description != String.Empty)
                Console.WriteLine("Описание: " + product.Description);
            Console.WriteLine();
        }
    }
}