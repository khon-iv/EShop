using System;
using System.Linq;

namespace EShop.Commands;

public static class DisplayCommandsCommand
{
    public const string Name = "DisplayCommands";
    public const string Description = "показать все команды";

    public static string Execute(string[]? args)
    {
        var lines = new string[]
        {
            $"{DisplayCommandsCommand.Name} - {DisplayCommandsCommand.Description}",
            $"{DisplayProductsCommand.Name} - {DisplayProductsCommand.Description}",
            $"{DisplayServicesCommand.Name} - {DisplayServicesCommand.Description}",
            $"{DisplayCartCommand.Name} - {DisplayCartCommand.Description}",
            $"{AddItemToCartCommand.Name} - {AddItemToCartCommand.Description}",
            $"{CreateOrderCommand.Name} - {CreateOrderCommand.Description}",
            $"{DisplayOrdersCommand.Name} - {DisplayOrdersCommand.Description}",
            $"{ExitCommand.Name} - {ExitCommand.Description}",
        };
        
        if (args is null || args.Length == 0)
        {
            return String.Join('\n', lines);
        }
        else
            return $"Некорректное число аргументов для команды {Name}";
    }
}