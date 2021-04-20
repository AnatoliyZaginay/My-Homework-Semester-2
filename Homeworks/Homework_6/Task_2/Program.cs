using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game("..//..//..//map.txt");
            var eventLoop = new EventLoop();
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DowntHandler += game.OnDown;

            eventLoop.Run();
        }
    }
}
