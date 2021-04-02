using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Add(1, 0);
            list.Add(2, 1);
            list.Add(4, 2);
            list.Add(5, 3);
            list.Add(3, 2);

            list.ChangeValue(221, 0);
            list.ChangeValue(222, 1);
            list.ChangeValue(223, 2);
            list.ChangeValue(224, 3);
            list.ChangeValue(225, 4);

            list.Delete(0);
            list.Delete(3);
            list.Delete(1);
            list.Delete(1);
            list.Delete(0);

            UniqueList uList = new UniqueList();
            uList.Add(1, 0);
            uList.Add(2, 1);
            uList.Add(4, 2);
            uList.Add(5, 3);
            uList.Add(3, 2);
            uList.Add(6, 5);
            uList.Add(3, 2);

            uList.ChangeValue(221, 0);
            uList.ChangeValue(222, 1);
            uList.ChangeValue(223, 2);
            uList.ChangeValue(224, 3);
            uList.ChangeValue(225, 4);
            uList.ChangeValue(6, 0);

        }
    }
}
