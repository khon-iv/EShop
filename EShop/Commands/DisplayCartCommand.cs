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
        _cart.AddItemToCart(Catalog.CatalogItems.First(i => i.Nomenclature.Id == 0).Nomenclature);
        _cart.AddItemToCart(Catalog.CatalogItems.First(i => i.Nomenclature.Id == 2).Nomenclature);
        _cart.AddItemToCart(Catalog.CatalogItems.First(i => i.Nomenclature.Id == 3).Nomenclature);
        _cart.AddItemToCart(Catalog.CatalogItems.First(i => i.Nomenclature.Id == 0).Nomenclature);
        
        if (args is null || args.Length == 0)
        {
            // LINQ return _cart.CartLines.Aggregate("", (current, cartLine) => current + $"{cartLine.Text}\n");
            decimal totalPrice = 0;
            var resultString = "";
            foreach (var cartLine in _cart.CartLines)
            {
                resultString += $"{cartLine.ItemNomenclature.Name} | {cartLine.Count} | " +
                                $"{cartLine.ItemNomenclature.Price} | {cartLine.ItemNomenclature.Price * cartLine.Count}\n";
                totalPrice += cartLine.ItemNomenclature.Price * cartLine.Count;
            }
            resultString += $"Total price: {totalPrice}";
            
            return resultString;
        }
        else 
            return $"Некорректное число аргументов для команды {Name}";
    }
    
}