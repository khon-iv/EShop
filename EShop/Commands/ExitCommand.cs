using System;

namespace EShop.Commands;

public static class ExitCommand
{
    public const string Name = "Exit";
    public const string Description = "завершить";

    public static void Execute(string[]? args)
    {
        if (args == null || args.Length == 0)
            System.Environment.Exit(0);
        else
            Console.WriteLine($"Некорректное число аргументов для команды {Name}");
    }
}