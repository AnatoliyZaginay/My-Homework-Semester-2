using System;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2 && (args[0] == "-c" || args[0] == "-u"))
            {
                if (!File.Exists(args[1]))
                {
                    Console.WriteLine("\nFile doesn't exists");
                    return;
                }

                if (args[0] == "-c")
                {
                    if (File.Exists(args[1] + ".zipped"))
                    {
                        Console.WriteLine($"\nFile with name \"{args[1]}.zipped\" already exists, do you want to overwrite it?");
                        Console.WriteLine("y - yes, n - no");
                        var choice = Console.ReadLine();
                        if (choice == "n")
                        {
                            return;
                        }
                        File.Delete(args[1] + ".zipped");
                    }
                    LZW.Compress(args[1]);
                    var file = new FileInfo(args[1]);
                    var compressedFile = new FileInfo(args[1] + ".zipped");
                    var coefficient = (double)file.Length / compressedFile.Length;
                    Console.WriteLine($"\nFile successfully compresssed. Compression coefficient: {Math.Round(coefficient, 5)}");
                    return;
                }

                if (args[0] == "-u" && args[1].Length > 7 && args[1].Substring(args[1].Length - 7, 7) == ".zipped")
                {
                    if (File.Exists(args[1].Substring(0, args[1].Length - 7)))
                    {
                        Console.WriteLine($"\nFile with name \"{args[1].Substring(0, args[1].Length - 7)}\" already exists, do you want to overwrite it?");
                        Console.WriteLine("y - yes, n - no");
                        var choice = Console.ReadLine();
                        if (choice == "n")
                        {
                            return;
                        }
                        File.Delete(args[1].Substring(0, args[1].Length - 7));
                    }
                    LZW.Decompress(args[1]);
                    Console.WriteLine("\nFile successfully uncompressed");
                }
                else
                {
                    Console.WriteLine("\nСompressed file must have an extension \".zipped\"");
                }
            }
            else
            {
                Console.WriteLine("\nIncorrect input");
                Console.WriteLine("Write \"-c file path\" to compress file");
                Console.WriteLine("Write \"-u file path\" to uncompress file");
            }
        }
    }
}