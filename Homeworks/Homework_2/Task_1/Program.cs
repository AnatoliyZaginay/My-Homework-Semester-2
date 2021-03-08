using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Console.ReadLine();
            LZW.Compress(path);
        }
    }
}
