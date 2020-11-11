using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Engine.Commands
{
    public interface ICommand
    {
        void Execute(GameState state);
    }
}
