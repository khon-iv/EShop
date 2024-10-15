using System.Collections.Generic;
using System.Linq;

namespace Core;

public static class ServiceCatalog
{
    private static readonly List<Service> Services = new List<Service>();
    public static IEnumerable<Service> ServicesForDisplay => Services.Where(service => (service.Price > 0)); 

    static ServiceCatalog()
    {
        CreateArrayOfServices();
    }

    private static void CreateArrayOfServices()
    {
        Services.AddRange(new List<Service>
        {
            new Service(
                0,
                "Установка встраиваемой посудомоечной машины",
                3000,
                "Подключение посудомоечной машины к водопроводу и канализации сложная работа"
            ),
            new Service(
                1,
                "Установка кондиционера (5000-11000 BTU) 3 метра",
                11500,
                "Установка кондиционера включает процедуру крепления внутреннего и внешнего блоков, " +
                "подключения межблочных коммуникаций, наладку и пробный запуск климатического оборудования."
                
            ),
            new Service(
                2,
                "Сборка Игрового ПК",
                3999,
                "Наши специалисты могут собрать компьютер, который максимально соответствует " +
                "вашим требованиям и сделают это быстро и качественно! "
                
            ),
            // не должна отображаться в каталоге, т.к. цена 0
            new Service(
                3,
                "Наклейка стекла на смартфон",
                description: "Мы предлагаем Вам услугу наклейки защитного стекла на устройство, " +
                             "гарантируя отсутствие дефектов."
            ),
            new Service(
                4,
                "Демонтаж и установка кондиционера (5000-11000 BTU)",
                15300
            )
        });
    }
}