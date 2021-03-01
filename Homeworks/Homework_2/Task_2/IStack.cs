using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    interface IStack
    {
        void Push(double value);

        bool IsEmpty();

        double Pop();
    }
}
