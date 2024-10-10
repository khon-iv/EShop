using Core;

namespace EShop.Commands;

public class AddItemToCartCommand(Cart cart)
{
    public const string Name = "AddItemToCartCommand";
    public const string Description = "показать корзину";

    public string Execute(string[]? args)
    {
        if (args is null || args.Length == 0)
            return $"Для команды {Name} в качестве аргументов необходимо указать номенклатуру " +
                   $"и количество (если больше 1)";
        if (args.Length > 2)
            return $"Для команды {Name} необходимо указать не более 2 агрументов:" +
                   $" номенклатуру и количество (если больше 1)";
        if (!int.TryParse(args[0], out var itemId))
            return $"Для команды {Name} в качестве первого аргумента необходимо указать номенклатуру (число)";
        else if (args.Length == 2)
            if (!int.TryParse(args[1], out var count))
                return $"Для команды {Name} в качестве второго аргумента необходимо указать количество (число)";
            else return 
                Catalog.getNomenclature(itemId) is null ? $"Номенклатура не найдена" : 
                    cart.AddItemToCart(Catalog.getNomenclature(itemId)!, count);
        
        return 
            Catalog.getNomenclature(itemId) is null ? $"Номенклатура не найдена" : 
                cart.AddItemToCart(Catalog.getNomenclature(itemId)!);
    }
}