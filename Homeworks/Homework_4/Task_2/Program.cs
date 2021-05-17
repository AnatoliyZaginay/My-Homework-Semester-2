using System;

namespace Task_2
{
    class Program
    {
          private static void Commands()
        {
            Console.WriteLine("\nCommands:");
            Console.WriteLine("0 - exit");
            Console.WriteLine("1 - add value:");
            Console.WriteLine("2 - change value");
            Console.WriteLine("3 - get value");
            Console.WriteLine("4 - delete element\n");
        }

        static void Main(string[] args)
        {
            var list = new UniqueList();

            var commandNumber = -1;
            while (commandNumber != 0)
            {
                Commands();
                commandNumber = int.Parse(Console.ReadLine());

                int index = 0;
                int value = 0;
                switch (commandNumber)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Write("Enter a value: ");
                        value = int.Parse(Console.ReadLine());
                        Console.Write("Enter an index: ");
                        index = int.Parse(Console.ReadLine());
                        try
                        {
                            list.Add(value, index);
                            Console.WriteLine("Element was successfully added.");
                        }
                        catch (ElementAlreadyExistsException)
                        {
                            Console.WriteLine("List already contains this value.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Index is incorrect.");
                        }
                        break;
                    case 2:
                        Console.Write("Enter a value to change: ");
                        value = int.Parse(Console.ReadLine());
                        Console.Write("Enter an index: ");
                        index = int.Parse(Console.ReadLine());
                        try
                        {
                            list.ChangeValue(value, index);
                            Console.WriteLine("Value was successfully changed.");
                        }
                        catch (ElementAlreadyExistsException)
                        {
                            Console.WriteLine("List already contains this value.");
                        }
                        catch (ElementDoesNotExistException)
                        {
                            Console.WriteLine("Element doesn't exist.");
                        }
                        break;
                    case 3:
                        Console.Write("Enter an index: ");
                        index = int.Parse(Console.ReadLine());
                        try
                        {
                            value = list.GetValue(index);
                            Console.WriteLine($"Returned value: {value}");
                        }
                        catch (ElementDoesNotExistException)
                        {
                            Console.WriteLine("Element doesn't exist.");
                        }
                        break;
                    case 4:
                        Console.Write("Enter an index: ");
                        index = int.Parse(Console.ReadLine());
                        try
                        {
                            list.Delete(index);
                            Console.WriteLine("Element was successfully deleted.");
                        }
                        catch (ElementDoesNotExistException)
                        {
                            Console.WriteLine("Element doesn't exist.");
                        }
                        break;
                    default:
                        Console.WriteLine("Command number is incorrect.");
                        break;
                }
            }
        }
    }
}