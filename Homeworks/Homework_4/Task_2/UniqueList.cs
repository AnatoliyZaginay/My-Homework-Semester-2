using System;

namespace Task_2
{
    public class UniqueList : List
    {
        private bool Contains(int value)
        {
            ListElement currentElement = head;
            for (int i = 0; i < count; ++i)
            {
                if (currentElement.Value == value)
                {
                    return true;
                }

                currentElement = currentElement.Next;
            }

            return false;
        }

        public override void Add(int value, int index)
        {
            if (Contains(value))
            {
                return;
            }
            base.Add(value, index);
        }

        public override void ChangeValue(int newValue, int index)
        {
            if (Contains(newValue))
            {
                return;
            }
            base.ChangeValue(newValue, index);
        }
    }
}
