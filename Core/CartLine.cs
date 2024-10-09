namespace Core;
/// <summary>
/// Линия корзины
/// </summary>
public class CartLine
{
    public readonly Nomenclature CartNomenclature;
    private int _count;
    
    /// <summary>
    /// Идентификатор линии
    /// </summary>
    public int Id => CartNomenclature.Id;
    
    /// <summary>
    /// Текст для отображения линии корзины
    /// </summary>
    public string Text => $"{CartNomenclature.Name} | {Count} | {CartNomenclature.Price} | {CartNomenclature.Price * Count}";
    
    /// <summary>
    /// Количество элементов в линии корзины
    /// </summary>
    public int Count
    {
        get => _count;
        set
        {
            if (((CartNomenclature.Type == NomenclatureTypes.Service) && (value > 1)) || value < 1)
                return;
            _count = value;
        }
    }
    
    public CartLine(Nomenclature nomenclature, int count)
    {
        CartNomenclature = nomenclature;
        Count = count;
    }
}