using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Engine.View
{
    public class View: IView
    {
        public void Render(GameState state)
        {
            var data = new int[8, 8];

            foreach (var i in state.Actions)
            {
                data[i.Item1, i.Item2] = 1;

                if (state.ExplodedMines.Contains(i) || state.UnexplodedMines.Contains(i))
                {
                    data[i.Item1, i.Item2] = 3;
                }
            }

            var currentItem = state.Actions.Peek();

            data[currentItem.Item1, currentItem.Item2] = 2;


            Console.Clear();

            PrintMap(data);

            Console.WriteLine("Number of mines:" + GameState.NumberOfMines);
            Console.WriteLine("lives left:" + state.Lives);
            Console.WriteLine("Number of steps:" + state.Actions.Count);
            Console.WriteLine("Current point:" + currentItem.Item1 + (char)('A' + currentItem.Item2));
            Console.WriteLine("Finish point:" + state.FinishPoint.Item1 + (char)('A' + state.FinishPoint.Item2));
        }

        public void RenderGameOver()
        {
            Console.WriteLine("Game Over!");
        }

        public void RenderWin()
        {
            Console.WriteLine("Win!");
        }

        private void PrintMap(int[,] data)
        {
            var horizontalLine = new StringBuilder();

            horizontalLine.Append("  ");
            for (var j = 0; j < data.GetLength(1); j++)
            {
                horizontalLine.Append("  - ");
            }

            Console.Write("    ");
            for (var j = 0; j < data.GetLength(1); j++)
            {
                Console.Write((char)('A' + j));
                Console.Write("   ");
            }

            Console.WriteLine(Environment.NewLine + horizontalLine);

            for (var i = 0; i < data.GetLength(0); i++)
            {
                Console.Write(i + 1 + " | ");
                for (var j = 0; j < data.GetLength(1); j++)
                {
                    Console.Write(data[i, j] == 0 ? " " : data[i, j] == 1 ? "@" : data[i, j] == 2 ? "+" : "*");
                    Console.Write(" | ");
                }
                Console.WriteLine(Environment.NewLine + horizontalLine);
            }
        }
    }
}
