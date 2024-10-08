namespace Core;

public class CatalogItem
{
    public int Id { get; }
    public Item Item { get; }

    private int _remains;
    public int Remains
    {
        get => _remains;
        set
        {
            if ((Item.Type == ItemTypes.Service) && (value != 1) || (value < 1))
                return;
            else
                _remains = value;
        }
    }

    public CatalogItem(Item item, int remains = 1)
    {
        Id = item.Id;
        Item = item;
        Remains = (item.Type == ItemTypes.Service) ? 1 : remains;
    }
}