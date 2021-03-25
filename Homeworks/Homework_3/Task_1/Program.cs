using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree tree = new BTree(3);
            tree.Insert("1", "1");
            tree.Insert("2", "2");
            tree.Insert("3", "3");
            tree.Insert("4", "4");
            tree.Insert("5", "5");
            tree.Insert("6", "6");
            tree.Insert("7", "7");
            tree.Insert("8", "3");
            tree.Insert("9", "4");
            tree.Insert("10", "5");
            tree.Insert("11", "6");
            tree.Insert("12", "7");
            tree.Insert("13", "3");
            tree.Insert("14", "4");
            tree.Insert("15", "5");
            tree.Insert("16", "6");
            tree.Insert("17", "7");
            tree.Insert("18", "7");
            tree.Insert("19", "3");
            tree.Insert("20", "4");
            tree.Insert("21", "5");
            tree.Insert("22", "6");
            tree.Insert("23", "7");
        }
    }
}
