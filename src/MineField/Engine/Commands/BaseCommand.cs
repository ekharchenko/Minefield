using MineField.Engine.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Engine.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected readonly IView _view;

        protected BaseCommand(IView view)
        {
           _view = view;
        }

        public virtual void Execute(GameState state)
        {
            var currentItem = state.Actions.Peek();

            if (state.UnexplodedMines.Contains(currentItem))
            {
                state.UnexplodedMines.Remove(currentItem);
                state.ExplodedMines.Add(currentItem);
                state.Lives--;
            }

            if(currentItem.Equals(state.FinishPoint))
            {
                state.Win = true;
            }

            _view.Render(state);
        }
    }
}
