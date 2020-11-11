using MineField.Engine.Commands;
using MineField.Engine.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Engine
{
    public class Game
    {
        private readonly IView _view;
        private readonly ICommandFactory _commandBuilder;

        public Game(IView view, ICommandFactory commandBuilder)
        {
            _view = view;
            _commandBuilder = commandBuilder;
        }

        public void Play()
        {
            var state = new GameState();

            _view.Render(state);

            while (state.Lives > 0 && !state.Win)
            {
                var keyInfo = Console.ReadKey().Key;

                _commandBuilder.GetCommand(keyInfo)?.Execute(state);
            }

            if(state.Win)
            {
                _view.RenderWin();
            }
            else
            {
                _view.RenderGameOver();
            }
        }
    }
}
