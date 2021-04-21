using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game("..//..//..//Map.txt", Console.Write, Console.SetCursorPosition);

            var eventLoop = new EventLoop();
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DowntHandler += game.OnDown;

            game.DrawMap();

            eventLoop.Run();
        }
    }
}
