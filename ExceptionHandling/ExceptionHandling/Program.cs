//c# application to read and write on a .txt file
using System;

namespace ExceptionHandling
{
    class Program
    {
        

        static void Main(string[] args)
        {
            FileIO fileIO = new FileIO();
            Console.Write("Give Directory path: ");
            fileIO.DirectoryPath = Console.ReadLine();
            Console.Write("Give file name: ");
            fileIO.FileName = Console.ReadLine();
            fileIO.readFile();
            Console.ReadKey();
        }
    }
}
