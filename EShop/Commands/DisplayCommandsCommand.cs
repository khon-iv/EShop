namespace EShop.Commands;

public static class DisplayCommandsCommand
{
    public const string Name = "DisplayCommands";
    public const string Description = "показать все команды";

    public static void Execute()
    {
        Console.WriteLine($"{DisplayCommandsCommand.Name} - {DisplayCommandsCommand.Description}");
        Console.WriteLine($"{DisplayProducts.Name} - {DisplayProducts.Description}");
        Console.WriteLine($"{DisplayServices.Name} - {DisplayServices.Description}");
        Console.WriteLine($"{ExitCommand.Name} - {ExitCommand.Description}");
        Console.WriteLine();
    }
}