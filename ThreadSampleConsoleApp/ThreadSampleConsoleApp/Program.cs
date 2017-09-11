using System;
using System.Threading;


namespace ThreadingSampleApp
{
    public class Alpha
    {
        public void Beta()
        {
            while (true)
            {
                Console.WriteLine("Alph.Beta is running in its own thread.");
            }
        }
    }

    public class Simple
    {
        public static int Main()
        {
            Console.WriteLine("Thread Start/Stop/Join Sample");
            Alpha alpha = new Alpha();
            //Use ThreadStart delegate to pass the method in Thread constructor
            Thread thread = new Thread(new ThreadStart(alpha.Beta));
            thread.Start();

            while (!thread.IsAlive) ;
            Thread.Sleep(1);
            try
            {
                thread.Abort();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Unable to abort!" + ex.Message);
            }

            thread.Join();
            Console.WriteLine();
            Console.WriteLine("Alpha.Beta has finished");
            try
            {
                Console.WriteLine("Try to restart the Alpha.Beta thread");
                thread.Start();
            }
            catch (ThreadStateException )
            {

                Console.WriteLine(">>>>ThreadStateException trying to restart Alpha.Beta. " );
                Console.WriteLine("Expected since aborted threads cannot be restarted.<<<<<");
            }
            Console.ReadKey();
            return 0;
        }
    }
}
