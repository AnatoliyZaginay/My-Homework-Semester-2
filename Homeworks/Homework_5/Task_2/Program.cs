using System;
using System.IO;

namespace Task_2
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect input");
                Console.WriteLine("Enter the path to the input file as the first argument and the path to the output file as the second argument.");
                return -1;
            }

            try
            {
                Routers.MakeOptimalNetwork(args[0], args[1]);
            }
            catch (ArgumentException exception)
            {
                Console.Error.WriteLine(exception.Message);
                return -1;
            }
            catch (GraphIsNotConnectedException exception)
            {
                Console.Error.WriteLine(exception.Message);
                return -1;
            }

            return 0;
        }
    }
}