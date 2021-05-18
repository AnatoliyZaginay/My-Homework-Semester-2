using System;

namespace Task_1
{
    class Program
    {
        private static void Commands()
        {
            Console.WriteLine("\nCommands:");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Insert a key-value pair into the tree");
            Console.WriteLine("2 - Delete value by key");
            Console.WriteLine("3 - Get the value by key");
            Console.WriteLine("4 - Check if the tree contains a key");
            Console.WriteLine("5 - Change the value by key\n");
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a degree of B-Tree: ");
            int degree = int.Parse(Console.ReadLine());
            BTree tree;
            try
            {
                tree = new BTree(degree);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The degree of the tree must be at least 2.");
                return;
            }

            int commandNumber = -1;
            while (commandNumber != 0)
            {
                Commands();
                Console.Write("Enter a number of command: ");
                commandNumber = int.Parse(Console.ReadLine());
                switch (commandNumber)
                {
                    case 0:
                        break;
                    case 1:
                        {
                            Console.Write("Enter a key: ");
                            string key = Console.ReadLine();
                            Console.Write("Enter a value: ");
                            string value = Console.ReadLine();
                            tree.Insert(key, value);
                            Console.WriteLine("The key-value pair was added successfully.");
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter a key: ");
                            string key = Console.ReadLine();
                            try
                            {
                                tree.Delete(key);
                                Console.WriteLine("The key-value pair was deleted successfully.");
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("The key isn't contained in the tree.");
                            }
                            catch (InvalidOperationException)
                            {
                                Console.WriteLine("The tree is empty");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Enter a key: ");
                            string key = Console.ReadLine();
                            try
                            {
                                string value = tree.GetValue(key);
                                Console.WriteLine($"Returned value: {value}");
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("The key isn't contained in the tree.");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Enter a key: ");
                            string key = Console.ReadLine();
                            if (tree.Contains(key))
                            {
                                Console.WriteLine("The key is contained in the tree.");
                            }
                            else
                            {
                                Console.WriteLine("The key isn't contained in the tree.");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Write("Enter a key: ");
                            string key = Console.ReadLine();
                            Console.Write("Enter a value: ");
                            string value = Console.ReadLine();
                            try
                            {
                                tree.ChangeValue(key, value);
                                Console.WriteLine("The value was changed.");
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("The key isn't contained in the tree.");
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid command number.");
                        break;
                }
            }
        }
    }
}