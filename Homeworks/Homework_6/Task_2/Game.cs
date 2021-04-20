using System;
using System.IO;

namespace Task_2
{
    public class Game
    {
        private int widght;

        private int height;

        private bool[,] map;

        private (int x, int y) playerPosition;
        
        public Game(string filePath)
        {
            Initialize(filePath);
        }

        private int findMaximumLength(string[] lines)
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

        private void Initialize(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            widght = findMaximumLength(lines);
            height = lines.Length;

            if (widght == 0 || height == 0)
            {
                throw new ArgumentException();
            }

            map = new bool[height, widght];

            for (int i = 0; i < height; ++i)
            {
                Console.WriteLine(lines[i]);
                for (int j = 0; j < lines[i].Length; ++j)
                {
                    if (lines[i][j] == '@')
                    {
                        playerPosition.y = i;
                        playerPosition.x = j;
                        continue;
                    }

                    if (lines[i][j] == '#')
                    {
                        map[i, j] = true;
                    }
                }
            }
        }

        private bool IsFree(int x, int y)
            => map[y, x];

        private void RedrawPlayer(int newX, int newY)
        {
            Console.SetCursorPosition(playerPosition.x, playerPosition.y);
            Console.Write(' ');
            Console.SetCursorPosition(newX, newY);
            Console.Write('@');
        }

        private void MovePlayer(int deltaX, int deltaY)
        {
            int newX = (playerPosition.x + deltaX + widght) % widght;
            int newY = (playerPosition.y + deltaY + height) % height;

            if (!IsFree(newX, newY))
            {
                RedrawPlayer(newX, newY);
                playerPosition.x = newX;
                playerPosition.y = newY;
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
