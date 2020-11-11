using MineField.Engine.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Engine.Commands
{
    public class ArrowRightCommand : BaseCommand
    {

        public ArrowRightCommand(IView view) : base(view)
        {

        }

        public override void Execute(GameState state)
        {
            var last = state.Actions.Peek();

            if (last.Item2 < 7)
            {
                state.Actions.Push(new Tuple<int, int>(last.Item1, last.Item2 + 1));
            }

            base.Execute(state);
        }
    }
}
