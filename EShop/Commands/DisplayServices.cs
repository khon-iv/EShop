using Core;

namespace EShop.Commands;

public static class DisplayServices
{
    public const string Name = "DisplayServices";
    public const string Description = "показать услуги";
    
    public static void Execute(int serviceCountForDisplay = -1)
    {
        if ((serviceCountForDisplay < 0) || (serviceCountForDisplay > ServiceCatalog.ServicesForDisplay.Count))
            serviceCountForDisplay = ServiceCatalog.ServicesForDisplay.Count;
        for (var i = 0; i < serviceCountForDisplay; i++)
        {
            Console.WriteLine(
                ServiceCatalog.ServicesForDisplay[i].Name + "\n" +
                "Цена: " + ServiceCatalog.ServicesForDisplay[i].Price
            );
            if (ServiceCatalog.ServicesForDisplay[i].Description != String.Empty)
                Console.WriteLine("Описание: " + ServiceCatalog.ServicesForDisplay[i].Description);
            Console.WriteLine();
        }
    }
}