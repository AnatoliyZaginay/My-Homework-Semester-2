using System;

namespace Task_2
{
    class BWTTests
    {
        private static bool TransformTest()
        {
            (var firstLine, var firstIndex) = BWT.Transform("abcabcdabaabc");
            (var secondLine, var secondIndex) = BWT.Transform("ananananana");
            (var thirdLine, var thirdIndex) = BWT.Transform("aaabbaaaabaabaa");
            return firstLine == "bdaccaaaabbbc" && secondLine == "nnnnnaaaaaa" &&
                thirdLine == "bbaaabaaaaaabaa" && firstIndex == 3 &&
                secondIndex == 5 && thirdIndex == 4;
        }

        private static bool ReverseTest()
        {
            var firstLine = BWT.ReverseTransform("bdaccaaaabbbc", 3);
            var secondLine = BWT.ReverseTransform("nnnnnaaaaaa", 5);
            var thirdLine = BWT.ReverseTransform("bbaaabaaaaaabaa", 4);
            return firstLine == "abcabcdabaabc" && secondLine == "ananananana" &&
                thirdLine == "aaabbaaaabaabaa";
        }

        public static bool Tests()
            => TransformTest() && ReverseTest();
    }
}