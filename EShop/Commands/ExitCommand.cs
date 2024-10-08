using System;

namespace EShop.Commands;

public static class ExitCommand
{
    public const string Name = "Exit";
    public const string Description = "завершить";

    public static string Execute(string[]? args)
    {
        if (args is null || args.Length == 0)
            System.Environment.Exit(0);
        else
            return $"Некорректное число аргументов для команды {Name}";
        
        return String.Empty;
    }
}