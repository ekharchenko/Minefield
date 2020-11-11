using MineField.Engine.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Engine.Commands
{
    public class ArrowLeftCommand : BaseCommand
    {
        public ArrowLeftCommand(IView view) : base(view)
        {

        }

        public override void Execute(GameState state)
        {
            var last = state.Actions.Peek();

            if (last.Item2 > 0)
            {
                state.Actions.Push(new Tuple<int, int>(last.Item1, last.Item2 - 1));
            }

            base.Execute(state);
        }
    }
}
