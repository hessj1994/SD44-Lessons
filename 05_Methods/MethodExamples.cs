using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_Methods
{
    [TestClass]
    public class MethodExamples
    {
        //1      2       3
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        public int Add(int numOne, int numTwo)
        {
            return numOne + numTwo;
        }

        [TestMethod]
        public void MethodExecution()
        {
            SayHello("George");
            SayHello("Josh");

            int total = Add(23,86);
            Console.WriteLine(total);
        }
    }
}
