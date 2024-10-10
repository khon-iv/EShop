namespace Core;

public class Order(int orderId, Cart cart)
{
    public int OrderId { get; } = orderId;
    public List<ItemLine> OrderLines { get; set; } = cart.CartLines;

    public OrderStatuses Status
    {
        get
        {
            if (PaymentAmount == 0)
                return OrderStatuses.NotPaid;
            else if (PaymentAmount == OrderTotalPrice)
                return OrderStatuses.Paid;
            else
                return OrderStatuses.PartiallyPaid;
        }
    }

    public decimal OrderTotalPrice => OrderLines.Select(line => line.ItemNomenclature.Price * line.Count).ToList().Sum();

    public decimal PaymentAmount = 0;

    public string AddItemToOrder(Nomenclature nomenclature, int count = 1)
    {
        return 
            $"Добавление в заказ {nomenclature.Name} в количестве {count}" +
            $"{Methods.AddItemToContainer(OrderLines, nomenclature, count)}";
    }

    public string PaidOrder(decimal amount)
    {
        if (OrderTotalPrice > amount + PaymentAmount)
        {
            var change = amount + PaymentAmount - OrderTotalPrice;
            amount -= change;
            
            return $"Заказ полностью оплачен, сдача: {change}";
        }
        
        PaymentAmount += amount;
        return PaymentAmount == OrderTotalPrice ? 
            "Заказ полностью оплачен" : 
            $"Оплата принята, необходимо внести еще {OrderTotalPrice - PaymentAmount}";
    }
}