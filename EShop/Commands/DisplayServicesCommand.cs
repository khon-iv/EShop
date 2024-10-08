using System;
using System.Linq;
using Core;

namespace EShop.Commands;

public class DisplayServicesCommand
{
    private readonly List<Service> _services;
    
    public const string Name = "DisplayServicesCommand";
    public const string Description = "показать услуги";

    public DisplayServicesCommand(List<Service> services)
    {
        _services = services;
    }
    
    public string Execute(string[]? args)
    {
        int serviceCountForDisplay = 0;
        if (args is null || args.Length == 0)
            serviceCountForDisplay = _services.Count;
        else if (args.Length == 1)
            if (int.TryParse(args[0], out var number))
                serviceCountForDisplay = number;
            else
                return $"Для команды {Name} в качестве аргумента может быть только число - количество услуг";
        else return $"Некорректное число аргументов для команды {Name}";
        
        if ((serviceCountForDisplay < 1) || (serviceCountForDisplay > _services.Count))
            serviceCountForDisplay = _services.Count;

        var resultString = "";
        for (var i = 0; i < serviceCountForDisplay; i++)
        {
            resultString += $"{_services[i].Name}\n" +
                            $"Цена: {_services[i].Price}\n";
            if (_services[i].Description != String.Empty)
                resultString +=  $"Описание: {_services[i].Description}\n";
            if (i < serviceCountForDisplay - 1)
                resultString += '\n';
        }
        
        return resultString;
    }
}