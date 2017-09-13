using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComposingDelegateSampleApp
{
    delegate void MyDelegate(string s);
    class Program
    {
        public static void printHello(string name)
        {
            Console.WriteLine("Hello {0}!",name);
        }

        public static void printGoodBye(string name)
        {
            Console.WriteLine("Good bye {0}!",name);
        }

        static void Main(string[] args)
        {
            MyDelegate delegate1, delegate2, delegate3, delegate4;
            delegate1 = new MyDelegate(printHello);
            delegate2 = new MyDelegate(printGoodBye);
            delegate3 = delegate1 + delegate2;
            delegate4 = delegate3 - delegate1;
            delegate1("Amit");
            delegate2("Amit");
            delegate3("Ajay");
            delegate4("Atul");
            Console.ReadKey();

        }
    }
}
