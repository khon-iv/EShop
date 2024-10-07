using System.Diagnostics;
using System.Xml;
using EShop.Commands;

namespace Eshop;

class EShop
{
    private static void Main(string[] args)
    {
        Console.WriteLine("EShop");
        DisplayCommandsCommand.Execute();
        while (true)
        {
            var command = Console.ReadLine();
            Execute(command);
        }
    }

    private static void Execute(string? command)
    {
        if (string.IsNullOrEmpty(command) || string.IsNullOrWhiteSpace(command)) 
        {
            Console.WriteLine("Введите команду");
            return;
        }
        
        var wordsOfCommand = command.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var commandName = wordsOfCommand[0];
        var commandArgs = new string[wordsOfCommand.Length - 1];
        Array.Copy(wordsOfCommand, 1, commandArgs, 0, wordsOfCommand.Length - 1);

        switch (commandName)
        {
            case DisplayCommandsCommand.Name:
                if (commandArgs.Length == 0)
                    DisplayCommandsCommand.Execute();
                else
                    Console.WriteLine($"Некорректное число аргументов для команды {commandName}");
                break;
            case ExitCommand.Name:
                if (commandArgs.Length == 0)
                    ExitCommand.Execute();
                else
                    Console.WriteLine($"Некорректное число аргументов для команды {commandName}");
                break;
            case DisplayProducts.Name:
                switch (commandArgs.Length)
                {
                    case 0:
                        DisplayProducts.Execute();
                        break;
                    case 1:
                        int.TryParse(commandArgs[0], out var num);
                        DisplayProducts.Execute(num);
                        break;
                    default:
                        Console.WriteLine($"Некорректное число аргументов для комманды {commandName}");
                        break;
                }
                break;
            case DisplayServices.Name:
                switch (commandArgs.Length)
                {
                    case 0:
                        DisplayServices.Execute();
                        break;
                    case 1:
                        int.TryParse(commandArgs[0], out var num);
                        DisplayServices.Execute(num);
                        break;
                    default:
                        Console.WriteLine($"Некорректное число аргументов для комманды {commandName}");
                        break;
                }
                break;
            default:
                Console.WriteLine("Неизвестная команда (чтобы посмотреть все команды, используйте DisplayCommands)");
                break;
        }
    } 
}