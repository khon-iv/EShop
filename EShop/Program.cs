using System;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using EShop.Commands;

namespace Eshop;

class EShop
{
    private static void Main(string[] args)
    {
        Console.WriteLine("EShop");
        DisplayCommandsCommand.Execute(null);
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
        
        var wordsOfCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var commandName = wordsOfCommand[0];
        var commandArgs = wordsOfCommand.Skip(1).ToArray();

        switch (commandName)
        {
            case DisplayCommandsCommand.Name:
                DisplayCommandsCommand.Execute(commandArgs);
                break;
            case ExitCommand.Name:
                ExitCommand.Execute(commandArgs);
                break;
            case DisplayProducts.Name:
                DisplayProducts.Execute(commandArgs);
                break;
            case DisplayServices.Name:
                DisplayServices.Execute(commandArgs);
                break;
            default:
                Console.WriteLine("Неизвестная команда (чтобы посмотреть все команды, введите DisplayCommands)");
                break;
        }
    } 
}