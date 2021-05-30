using System;

namespace IOCContainer.Example
{
    public class Test2 : ITest2
    {

        public Test2(string test2, ITest test, string test3)
        {
            Console.WriteLine($"Test2: {test2}");
            Console.WriteLine($"Test3: {test3}");
            test.Print();
        }

        public void Output()
        {
            Console.WriteLine("I am ITEST2");
        }
    }
}