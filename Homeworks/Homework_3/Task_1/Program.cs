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
            tree.Insert("11", "1");
            tree.Insert("12", "2");
            tree.Insert("13", "3");
            tree.Insert("14", "4");
            tree.Insert("15", "5");
            tree.Insert("16", "6");
            tree.Insert("17", "7");
            tree.Insert("18", "3");
            tree.Insert("19", "4");
            tree.Insert("20", "5");
            tree.Insert("21", "2");
            tree.Insert("22", "2");
            tree.Insert("23", "2");
            tree.Insert("24", "2");
            tree.Insert("25", "2");
            tree.Insert("26", "2");
            tree.Insert("27", "2");

            tree.Delete("17");
            tree.Delete("2");
            tree.Delete("19");
            tree.Delete("18");
            tree.Delete("22");
            tree.Delete("21");
            tree.Delete("20");
            tree.Delete("11");
            tree.Delete("1");
            tree.Delete("5");
            tree.Delete("14");
            tree.Delete("23");
            tree.Delete("25");
            tree.Delete("9");
            tree.Delete("8");
            tree.Delete("27");
            tree.Delete("10");
            tree.Delete("13");
            tree.Delete("26");
            tree.Delete("3");
            tree.Delete("24");
            tree.Delete("7");
            tree.Delete("12");
            tree.Delete("15");
        }
    }
}
