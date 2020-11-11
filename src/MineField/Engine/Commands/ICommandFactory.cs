using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Engine.Commands
{
    public interface ICommandFactory
    {
        ICommand GetCommand(ConsoleKey key);
    }
}
