namespace Core;

public class Order
{
    public int OrderId { get; }
    public List<ItemLine> OrderLines { get; set; }

    public OrderStatuses Status
    {
        get
        {
            if (PaymentAmount == 0)
                return OrderStatuses.NotPaid;
            else if (PaymentAmount == OrderTotal)
                return OrderStatuses.Paid;
            else
                return OrderStatuses.PartiallyPaid;
        }
    }

    public decimal OrderTotal => OrderLines.Select(line => line.ItemNomenclature.Price * line.Count).ToList().Sum();

    public decimal PaymentAmount = 0;

    public Order(int orderId, Cart cart)
    {
        OrderId = orderId;
        OrderLines = cart.CartLines;
    }

    public string AddItemToOrder(Nomenclature nomenclature, int count = 1)
    {
        return 
            $"Добавление в заказ {nomenclature.Name} в количестве {count}" +
            $"{Methods.AddItemToContainer(OrderLines, nomenclature, count)}";
    }

    public string PaidOrder(decimal amount)
    {
        if (OrderTotal > amount + PaymentAmount)
        {
            var change = amount + PaymentAmount - OrderTotal;
            amount -= change;
            
            return $"Заказ полностью оплачен, сдача: {change}";
        }
        
        PaymentAmount += amount;
        if (PaymentAmount == OrderTotal)
            return "Заказ полностью оплачен";
        else
            return $"Оплата принята, необходимо внести еще {OrderTotal - PaymentAmount}";
    }
}