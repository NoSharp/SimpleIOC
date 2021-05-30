using System;

namespace IOCContainer.Example
{
    public class Test : ITest
    {

        public Test()
        {
        }

        public void Print()
        {
            Console.WriteLine("Test!?!?!");
        }
    }
}