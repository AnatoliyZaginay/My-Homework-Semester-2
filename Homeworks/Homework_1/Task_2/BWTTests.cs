using System;

namespace Task_2
{
    class BWTTests
    {
        private static bool TransformTest()
        {
            int firstIndex = 0;
            int secondIndex = 0;
            int thirdIndex = 0;
            var firstLine = BWT.Transform("abcabcdabaabc", ref firstIndex);
            var secondLine = BWT.Transform("ananananana", ref secondIndex);
            var thirdLine = BWT.Transform("aaabbaaaabaabaa", ref thirdIndex);
            return String.Compare(firstLine, "bdaccaaaabbbc") == 0 && String.Compare(secondLine, "nnnnnaaaaaa") == 0 &&
                String.Compare(thirdLine, "bbaaabaaaaaabaa") == 0 && firstIndex == 3 &&
                secondIndex == 5 && thirdIndex == 4;
        }

        private static bool ReverseTest()
        {
            var firstLine = BWT.ReverseTransform("bdaccaaaabbbc", 3);
            var secondLine = BWT.ReverseTransform("nnnnnaaaaaa", 5);
            var thirdLine = BWT.ReverseTransform("bbaaabaaaaaabaa", 4);
            return String.Compare(firstLine, "abcabcdabaabc") == 0 && String.Compare(secondLine, "ananananana") == 0 &&
                String.Compare(thirdLine, "aaabbaaaabaabaa") == 0;
        }

        public static bool Tests()
            => TransformTest() && ReverseTest();
    }
}
