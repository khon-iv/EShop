namespace EShop.Commands;

public static class ExitCommand
{
    public const string Name = "Exit";
    public const string Description = "завершить";

    public static void Execute()
    {
        System.Environment.Exit(0);
    }
}