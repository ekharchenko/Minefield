using System;
using System.Collections.Generic;

namespace MineField.Engine.Commands
{
    public class CommandFactory: ICommandFactory
    {
        private readonly IDictionary<ConsoleKey, ICommand> _commands;

        public CommandFactory(IDictionary<ConsoleKey, ICommand> commands)
        {
            _commands = commands;
        }

        public ICommand GetCommand(ConsoleKey key)
        {
            return _commands.ContainsKey(key) ? _commands[key] : null;
        }
    }
}