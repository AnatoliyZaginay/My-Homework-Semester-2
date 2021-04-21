using System;
using System.IO;

namespace Task_2
{
    public class Game
    {
        public int Widght { get; private set; }

        public int Height { get; private set; }

        public bool[,] BoolMap { get; private set; }

        public string[] Map { get; private set; }

        public (int x, int y) PlayerPosition { get; private set; }

        private Action<string> Write;

        private Action<int, int> SetCursor;

        public Game(string filePath, Action<string> WriteFunction, Action<int, int> SetCursorFunction)
        {
            Write = WriteFunction;
            SetCursor = SetCursorFunction;
            Initialize(filePath);
        }

        private int FindMaximumLength(string[] lines)
        {
            int maximumLength = 0;
            for (int i = 0; i < lines.Length; ++i)
            {
                if (maximumLength < lines[i].Length)
                {
                    maximumLength = lines[i].Length;
                }
            }

            return maximumLength;
        }

        public void DrawMap()
        {
            for (int i = 0; i < Map.Length; ++i)
            {
                SetCursor(0, i);
                Write(Map[i]);
            }
        }

        private void Initialize(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("File does not exists");
            }

            Map = File.ReadAllLines(filePath);
            Widght = FindMaximumLength(Map);
            Height = Map.Length;

            if (Widght == 0 || Height == 0)
            {
                throw new ArgumentException("Invalid map size");
            }

            BoolMap = new bool[Height, Widght];
            bool isPlayerOnMap = false;

            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Map[i].Length; ++j)
                {
                    if (Map[i][j] == '@')
                    {
                        if (isPlayerOnMap)
                        {
                            throw new ArgumentException("More than one player on map");
                        }

                        isPlayerOnMap = true;

                        PlayerPosition = (j, i);
                        continue;
                    }

                    if (Map[i][j] == '#')
                    {
                        BoolMap[i, j] = true;
                    }
                }
            }

            if (!isPlayerOnMap)
            {
                throw new ArgumentException("Player is not on map");
            }
        }

        private bool IsFree(int x, int y)
            => BoolMap[y, x];

        private void RedrawPlayer(int newX, int newY)
        {
            SetCursor(PlayerPosition.x, PlayerPosition.y);
            Write(" ");
            SetCursor(newX, newY);
            Write("@");
        }

        private void MovePlayer(int deltaX, int deltaY)
        {
            int newX = (PlayerPosition.x + deltaX + Widght) % Widght;
            int newY = (PlayerPosition.y + deltaY + Height) % Height;

            if (!IsFree(newX, newY))
            {
                RedrawPlayer(newX, newY);
                PlayerPosition = (newX, newY);
            }
        }

        public void OnLeft(object sender, EventArgs args)
            => MovePlayer(-1, 0);

        public void OnRight(object sender, EventArgs args)
            => MovePlayer(1, 0);

        public void OnUp(object sender, EventArgs args)
            => MovePlayer(0, -1);

        public void OnDown(object sender, EventArgs args)
            => MovePlayer(0, 1);
    }
}
