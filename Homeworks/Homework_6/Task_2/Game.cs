using System;
using System.IO;

namespace Task_2
{
    /// <summary>
    /// Class of simple game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Widght of the game map.
        /// </summary>
        public int Widght { get; private set; }

        /// <summary>
        /// Height of the game map.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Boolean representation of the game map.
        /// </summary>
        public bool[,] BoolMap { get; private set; }

        /// <summary>
        /// String representation of the game map.
        /// </summary>
        public string[] Map { get; private set; }

        /// <summary>
        /// Player position on the game map.
        /// </summary>
        public (int x, int y) PlayerPosition { get; private set; }

        /// <summary>
        /// Function of drawing game objects.
        /// </summary>
        private Action<string> Write;

        /// <summary>
        /// Cursor setting function.
        /// </summary>
        private Action<int, int> SetCursor;

        /// <summary>
        /// Creates a new game by the game map file, the specified writing function and the specified cursor setting function.
        /// </summary>
        /// <param name="filePath">Path to the game map file.</param>
        /// <param name="WriteFunction">Specified writing function.</param>
        /// <param name="SetCursorFunction">Specified cursor setting function.</param>
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

        /// <summary>
        /// Draws game map.
        /// </summary>
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

        /// <summary>
        /// Moves the player to the left if possible.
        /// </summary>
        public void OnLeft(object sender, EventArgs args)
            => MovePlayer(-1, 0);

        /// <summary>
        /// Moves the player to the right if possible.
        /// </summary>
        public void OnRight(object sender, EventArgs args)
            => MovePlayer(1, 0);

        /// <summary>
        /// Moves the player up if possible.
        /// </summary>
        public void OnUp(object sender, EventArgs args)
            => MovePlayer(0, -1);

        /// <summary>
        /// Moves the player down if possible.
        /// </summary>
        public void OnDown(object sender, EventArgs args)
            => MovePlayer(0, 1);
    }
}