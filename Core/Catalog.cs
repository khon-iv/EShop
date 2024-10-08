namespace Core;

public class Catalog
{
    public static List<CatalogItem> CatalogItems = GetItems();

    private static List<CatalogItem> GetItems()
    {
        var items = new List<CatalogItem>();
        items.AddRange(new List<CatalogItem>
        {
            new CatalogItem(
                new Item(
                    0,
                    "Электрочайник BEON BN-006 синий",
                    450,
                    ItemTypes.Product,
                    "Электрический чайник BEON BN-006 предназначен для кипячения воды. " +
                    "В модели открытая спираль. Функцию автоотключения прибор не имеет."
                    ),
                5
                ),
            new CatalogItem(
                new Item(
                    1,
                    "Фен Aceline BA-100 красный/черный",
                    599,
                    ItemTypes.Product
                    ),
                7
                ),
            new CatalogItem(
                new Item(
                    2,
                    "6.7\" Смартфон realme Note 50 64 ГБ черный",
                    7499,
                    ItemTypes.Product
                    ),
                10
                ),
            new CatalogItem(
                new Item(
                    3,
                    "24\" (61 см) LED-телевизор Aceline 24HEN1 черный",
                    1199,
                    ItemTypes.Product
                    )
                ),
            new CatalogItem(
                new Item(
                    4,
                    "14.1\" Ноутбук DEXP Aquilon серебристый",
                    10000,
                    ItemTypes.Product,
                    "Aquilon оборудован сенсорным NumPad, который упрощает ввод числовой информации. "
                    ),
                14
                ),
            new CatalogItem(
                new Item(
                    5,
                    "Установка встраиваемой посудомоечной машины",
                    3000,
                    ItemTypes.Service,
                    "Подключение посудомоечной машины к водопроводу и канализации сложная работа"
                    )
                ),
            new CatalogItem(
                new Item(
                    6,
                    "Установка кондиционера (5000-11000 BTU) 3 метра",
                    11500,
                    ItemTypes.Service,
                    "Установка кондиционера включает процедуру крепления внутреннего и внешнего блоков, " +
                    "подключения межблочных коммуникаций, наладку и пробный запуск климатического оборудования."
                    )
                ),
            new CatalogItem(
                new Item(
                    7,
                    "Сборка Игрового ПК",
                    3999,
                    ItemTypes.Service,
                    "Наши специалисты могут собрать компьютер, который максимально соответствует " +
                    "вашим требованиям и сделают это быстро и качественно! "
                    )
                ),
            new CatalogItem(
                new Item(
                    8,
                    "Наклейка стекла на смартфон",
                    0,
                    ItemTypes.Service,
                    "Мы предлагаем Вам услугу наклейки защитного стекла на устройство, " +
                             "гарантируя отсутствие дефектов."
                    )
                ),
            new CatalogItem(
                new Item(
                    9,
                    "Демонтаж и установка кондиционера (5000-11000 BTU)",
                    15300,
                    ItemTypes.Service
                    )
                )
        });
        
        return items;
    }
}