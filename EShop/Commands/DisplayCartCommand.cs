using Core;

namespace EShop.Commands;

public class DisplayCartCommand
{
    private readonly Cart _cart;
    
    public const string Name = "DisplayCartCommand";
    public const string Description = "показать корзину";

    public DisplayCartCommand(Cart cart)
    {
        _cart = cart;
    }

    public string Execute(string[]? args)
    {
        ///
        _cart.AddCartLine(Catalog.CatalogItems.First(i => i.Item.Id == 0).Item);
        _cart.AddCartLine(Catalog.CatalogItems.First(i => i.Item.Id == 2).Item);
        _cart.AddCartLine(Catalog.CatalogItems.First(i => i.Item.Id == 3).Item);
        _cart.AddCartLine(Catalog.CatalogItems.First(i => i.Item.Id == 0).Item);
        
        if (args is null || args.Length == 0)
        {
            // LINQ return _cart.CartLines.Aggregate("", (current, cartLine) => current + $"{cartLine.Text}\n");
            var resultString = "";
            foreach (var cartLine in _cart.CartLines)
                resultString += $"{cartLine.Text}\n";
        
            return resultString;
        }
        else 
            return $"Некорректное число аргументов для команды {Name}";
    }
    
}