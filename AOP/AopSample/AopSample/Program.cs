using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var w = new Worker();

            w.DoSomething1();
            w.DoSomething2();

            var result = w.DoSomething3();
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
