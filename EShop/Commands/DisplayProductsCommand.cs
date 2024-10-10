using System;
using System.Linq;
using Core;

namespace EShop.Commands;

/// <summary>
/// Команда отображения товаров
/// </summary>
public class DisplayProductsCommand
{
    private readonly List<CatalogItem> _products;
    
    /// <summary>
    /// Наименование команды
    /// </summary>
    public const string Name = "DisplayProductsCommand";
    
    /// <summary>
    /// Описание команды
    /// </summary>
    public const string Description = "показать товары";

    public DisplayProductsCommand(List<CatalogItem> products)
    {
        _products = products.Where(p => p is {Remains: > 0, Nomenclature.Price: > 0}).ToList();
    }
    
    /// <summary>
    /// Выполнить команду
    /// </summary>
    public string Execute(string[]? args)
    {
        var productCountForDisplay = 0;
        if (args is null || args.Length == 0)
            productCountForDisplay = _products.Count;
        else if (args.Length == 1)
            if (int.TryParse(args[0], out var number))
                productCountForDisplay = number;
            else
                return $"Для команды {Name} в качестве аргумента может быть только число - количество товаров";
        else return $"Некорректное число аргументов для команды {Name}";
        
        if ((productCountForDisplay < 1) || (productCountForDisplay > _products.Count))
            productCountForDisplay = _products.Count;
        
        var resultString = "";
        for (var i = 0; i < productCountForDisplay; i++)
        {
            resultString += $"{_products[i].Nomenclature.Name}\n" +
                   $"Цена: {_products[i].Nomenclature.Price}\n" +
                   $"Остаток: {_products[i].Remains}\n";
            if (_products[i].Nomenclature.Description != String.Empty)
                resultString += $"Описание: {_products[i].Nomenclature.Description}\n";
            if (i < productCountForDisplay - 1)
                resultString += '\n';
        }
        
        return resultString;
    }
}