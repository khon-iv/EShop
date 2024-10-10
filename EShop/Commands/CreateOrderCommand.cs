using Core;

namespace EShop.Commands;

public class CreateOrderCommand
{
    private readonly List<Order> _orders;
    private readonly Cart _cart;
    
    public const string Name = "CreateOrderCommand";
    public const string Description = "создать заказ";

    public CreateOrderCommand(List<Order> orders, Cart cart)
    {
        _orders = orders;
        _cart = cart;
    }

    public string Execute(string[]? args)
    {
        if (args is null || args.Length == 0)
        {
            if (_cart.CartLines.Count == 0)
                return "Невозможно создать заказ: в корзине ничего нет.";
            
            _orders.Add(new(_orders.Count == 0 ? 0 : _orders.Last().OrderId + 1, _cart));
            return "Заказ создан";
        }
        else
            return $"Некорректное число аргументов для команды {Name}";
    }
}