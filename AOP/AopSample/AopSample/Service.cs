using System;

namespace AopSample
{
    public class Service : IService
    {
        public void Do()
        {
            Console.WriteLine("Doing work");
        }

        public string DoAndReturn()
        {
            Console.WriteLine("Doing work and returning result");
            return "Result";
        }

        public void Abort()
        {
            Console.WriteLine("Aborting");
        }

        public void Close()
        {
            Console.WriteLine("Closing");
        }
    }
}
