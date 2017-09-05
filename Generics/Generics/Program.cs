using System;

namespace Generics
{
    

    class Program
    {
        static void Main(string[] args)
        {

            GenericList<int> integerList = new GenericList<int>();
            GenericList<string> stringList = new GenericList<string>();
            integerList.AddData(1);
            integerList.AddData(2);
            integerList.AddData(3);
            stringList.AddData("Ajay");
            stringList.AddData("M.");
            integerList.showList();
            stringList.showList();
            Console.ReadKey();
        }
    }
}
