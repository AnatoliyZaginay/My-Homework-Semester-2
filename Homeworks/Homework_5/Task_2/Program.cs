using System;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] lengths = { { 0, 78, 0, 0, 16 },
                               { 78, 0, 17, 22, 6 },
                               { 0, 17, 0, 30, 0 },
                               { 0, 22, 30, 0, 29 },
                               { 16, 6, 0, 29, 0 } };
            bool[,] connections = { { true, true, false, false, true },
                                    { true, true, true, true, true },
                                    { false, true, true, true, false },
                                    { false, true, true, true, true },
                                    { true, true, false, true, true } };

            var graph = new Graph(lengths, connections);
            var tree = graph.GetSpanningTree();
            bool a = graph.IsConnected();

            string path = "C:\\Users\\User\\Desktop\\r.txt";
            string res = "C:\\Users\\User\\Desktop\\res.txt";

            var graphA = new Graph(path);
            var treeA = graphA.GetSpanningTree();
            treeA.WriteGraphToFile(res);
        }
    }
}
