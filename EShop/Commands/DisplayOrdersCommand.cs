using Core;

namespace EShop.Commands;

public class DisplayOrdersCommand(List<Order> orders)
{
    public const string Name = "DisplayOrdersCommand";
    public const string Description = "показать активные заказы";

    public string Execute(string[]? args)
    {
        if (args is null || args.Length == 0)
        {
            if (orders.Count == 0)
                return "Нет активных заказов";
            
            var resultString = "";
            var orderIndex = 1;
            foreach (var order in orders)
            {
                resultString += $"\nЗаказ {orderIndex}\n" + 
                                order.OrderLines.Aggregate("", (currentLine, nextLine) => currentLine +
                                                            $"{nextLine.ItemNomenclature.Name} | {nextLine.Count} | " +
                                                            $"{nextLine.ItemNomenclature.Price} | " +
                                                            $"{nextLine.ItemNomenclature.Price * nextLine.Count}\n") +
                                $"Сумма итого: {order.OrderTotalPrice}\n" +
                                $"Оплачено: {order.PaymentAmount}\n";
                orderIndex++;
            }
            
            return resultString;
        }
        else 
            return $"Некорректное число аргументов для команды {Name}";
    }
}