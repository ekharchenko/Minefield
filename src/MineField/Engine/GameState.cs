using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Engine
{
    public class GameState
    {
        public Stack<Tuple<int, int>> Actions { get; private set; } = new Stack<Tuple<int, int>>();

        public List<Tuple<int, int>> UnexplodedMines { get; private set; } = new List<Tuple<int, int>>();

        public List<Tuple<int, int>> ExplodedMines { get; private set; } = new List<Tuple<int, int>>();

        public Tuple<int, int> StartPoint { get; private set; } = new Tuple<int, int>(0, 0);

        public Tuple<int, int> FinishPoint { get; private set; } = new Tuple<int, int>(7, 7);

        public int Lives { get; set; } = 6;

        public bool Win { get; set; }

        public const int NumberOfMines = 20;

        private readonly Random _rnd = new Random();

        public GameState()
        {
            for (int i = 0; i < NumberOfMines; i++)
            {
                UnexplodedMines.Add(new Tuple<int, int>(_rnd.Next(0, 8), _rnd.Next(0, 8)));
            }

            Actions.Push(StartPoint);
        }
    }
}
