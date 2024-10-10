namespace Core;

/// <summary>
/// Заказ
/// </summary>
public class Order(int orderId, Cart cart)
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public int OrderId { get; } = orderId;
    
    /// <summary>
    /// Линия заказа
    /// </summary>
    public List<ItemLine> OrderLines { get; set; } = cart.CartLines;
    
    /// <summary>
    /// Статус оплаты заказа
    /// </summary>
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
    
    /// <summary>
    /// Итоговая стоимость заказа
    /// </summary>
    public decimal OrderTotalPrice => OrderLines.Select(line => line.ItemNomenclature.Price * line.Count).ToList().Sum();
    
    /// <summary>
    /// Сумма полученной оплаты по заказу
    /// </summary>
    public decimal PaymentAmount = 0;
    
    /// <summary>
    /// Добавить элемент в заказ
    /// </summary>
    public string AddItemToOrder(Nomenclature nomenclature, int count = 1)
    {
        return 
            $"Добавление в заказ {nomenclature.Name} в количестве {count}" +
            $"{Methods.AddItemsToContainer(OrderLines, nomenclature, count)}";
    }

    /// <summary>
    /// Оплатить заказ
    /// </summary>
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