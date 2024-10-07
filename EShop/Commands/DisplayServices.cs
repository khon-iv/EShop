using System;
using System.Linq;
using Core;

namespace EShop.Commands;

public static class DisplayServices
{
    public const string Name = "DisplayServices";
    public const string Description = "показать услуги";
    
    public static void Execute(string[]? args)
    {
        int serviceCountForDisplay = 0;
        if (args is null || args.Length == 0)
            serviceCountForDisplay = ServiceCatalog.ServicesForDisplay.Count();
        else if (args.Length == 1)
            if (int.TryParse(args[0], out var number))
                serviceCountForDisplay = number;
            else
            {
                Console.WriteLine($"Для команды {Name} в качестве аргуимента может быть только число - количество услуг");
                return;
            }
        if ((serviceCountForDisplay < 1) || (serviceCountForDisplay > ServiceCatalog.ServicesForDisplay.Count()))
            serviceCountForDisplay = ServiceCatalog.ServicesForDisplay.Count();
        foreach (var service in ServiceCatalog.ServicesForDisplay)
        {
            Console.WriteLine(
                service.Name + "\n" +
                "Цена: " + service.Price
            );
            if (service.Description != String.Empty)
                Console.WriteLine("Описание: " + service.Description);
            Console.WriteLine();
        }
    }
}