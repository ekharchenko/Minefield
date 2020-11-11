using MineField.Engine.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Engine.Commands
{
    public class ArrowUpCommand : BaseCommand
    {
        public ArrowUpCommand(IView view):base(view)
        {
          
        }

        public override void Execute(GameState state)
        {
            var last = state.Actions.Peek();

            if (last.Item1 > 0)
            {
                state.Actions.Push(new Tuple<int, int>(last.Item1 - 1, last.Item2));
            }

            base.Execute(state);
        }
    }
}
