using System;

namespace EShop.Commands;

public static class DisplayCommandsCommand
{
    public const string Name = "DisplayCommands";
    public const string Description = "показать все команды";

    public static void Execute(string[]? args)
    {
        if (args == null || args.Length == 0)
        {
            Console.WriteLine($"{DisplayCommandsCommand.Name} - {DisplayCommandsCommand.Description}");
            Console.WriteLine($"{DisplayProducts.Name} - {DisplayProducts.Description}");
            Console.WriteLine($"{DisplayServices.Name} - {DisplayServices.Description}");
            Console.WriteLine($"{ExitCommand.Name} - {ExitCommand.Description}");
            Console.WriteLine();
        }
        else
            Console.WriteLine($"Некорректное число аргументов для команды {Name}");
    }
}