using Core;

namespace EShop.Commands;

public class CreateOrderCommand(List<Order> orders, Cart cart)
{
    public const string Name = "CreateOrderCommand";
    public const string Description = "создать заказ";

    public string Execute(string[]? args = null)
    {
        if (args is null || args.Length == 0)
        {
            if (cart.CartLines.Count == 0)
                return "Невозможно создать заказ: в корзине ничего нет.";
            
            orders.Add(new Order(orders.Count == 0 ? 0 : orders.Last().OrderId + 1, cart));

            cart.CartLines = [];
            
            return "Заказ создан";
        }
        else
            return $"Некорректное число аргументов для команды {Name}";
    }
}