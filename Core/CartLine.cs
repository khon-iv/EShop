namespace Core;
/// <summary>
/// Линия корзины
/// </summary>
public class CartLine
{
    private readonly Item _cartItem;
    private int _count;
    
    /// <summary>
    /// Идентификатор линии
    /// </summary>
    public int Id => _cartItem.Id;
    
    /// <summary>
    /// Текст для отображения линии корзины
    /// </summary>
    public string Text => $"{_cartItem.Name} | {Count}";
    
    /// <summary>
    /// Количество элементов в линии корзины
    /// </summary>
    public int Count
    {
        get => _count;
        set
        {
            if (((_cartItem.Type == ItemTypes.Service) && (value > 1)) || value < 1)
                return;
            _count = value;
        }
    }
    
    public CartLine(Item item, int count)
    {
        _cartItem = item;
        Count = count;
    }
}