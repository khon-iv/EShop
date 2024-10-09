using System;
using System.Collections.Generic;
using System.Windows.Input;
using Core;
using EShop.Commands;

namespace EShop;

public class ApplicationContext
{
    public const string Title = "EShop";

    private List<CatalogItem> _products = 
        Catalog.CatalogItems.Where(i => i.Nomenclature.Type == NomenclatureTypes.Product).ToList();
    private List<CatalogItem> _services = 
        Catalog.CatalogItems.Where(i => i.Nomenclature.Type == NomenclatureTypes.Service).ToList();
    
    private Cart _cart = new Cart();
    
    public string ExecuteStartupCommand()
    {
        return ExecuteCommandByName(DisplayCommandsCommand.Name);
    }

    public string ExecuteCommandByName(string commandName, string[]? commandArgs = null)
    {
        return commandName switch
        {
            DisplayCommandsCommand.Name => DisplayCommandsCommand.Execute(commandArgs),
            ExitCommand.Name => ExitCommand.Execute(commandArgs),
            DisplayProductsCommand.Name => new DisplayProductsCommand(_products).Execute(commandArgs),
            DisplayServicesCommand.Name => new DisplayServicesCommand(_services).Execute(commandArgs),
            DisplayCartCommand.Name => new DisplayCartCommand(_cart).Execute(commandArgs),
            var _ => "Неизвестная команда (чтобы посмотреть все команды, введите DisplayCommands)"
        };
    }
}