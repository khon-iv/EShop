namespace Core;

public class CatalogItem
{
    public int Id { get; }
    public Nomenclature Nomenclature { get; }

    private int _remains;
    public int Remains
    {
        get => _remains;
        set
        {
            if ((Nomenclature.Type == NomenclatureTypes.Service) && (value != 1) || (value < 1))
                return;
            else
                _remains = value;
        }
    }

    public CatalogItem(Nomenclature nomenclature, int remains = 1)
    {
        Id = nomenclature.Id;
        Nomenclature = nomenclature;
        Remains = (nomenclature.Type == NomenclatureTypes.Service) ? 1 : remains;
    }
}