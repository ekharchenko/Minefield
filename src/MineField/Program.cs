using Microsoft.Extensions.DependencyInjection;
using MineField.Engine;
using MineField.Engine.Commands;
using MineField.Engine.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineField
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IView, View>()
                .AddSingleton<ArrowRightCommand>()
                .AddSingleton<ArrowDownCommand>()
                .AddSingleton<ArrowLeftCommand>()
                .AddSingleton<ArrowUpCommand>()
                .AddSingleton<ICommandFactory, CommandFactory>(serviceProvider => new CommandFactory(new Dictionary<ConsoleKey, ICommand>() {
                { ConsoleKey.UpArrow, serviceProvider.GetService<ArrowUpCommand>() },
                { ConsoleKey.DownArrow, serviceProvider.GetService<ArrowDownCommand>() },
                { ConsoleKey.LeftArrow, serviceProvider.GetService<ArrowLeftCommand>() },
                { ConsoleKey.RightArrow, serviceProvider.GetService<ArrowRightCommand>() } }))
                .AddSingleton<Game>()
                .BuildServiceProvider();


            serviceProvider.GetService<Game>().Play();
            
        }

    }
}
