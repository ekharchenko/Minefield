using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Engine.View
{
    public interface IView
    {
        void Render(GameState state);
        void RenderGameOver();
        void RenderWin();
    }
}
