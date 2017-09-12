using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPoolSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.DoWork();
            
            Console.ReadKey();
        }

        public void DoWork()
        {
            // Queue a task.  
            System.Threading.ThreadPool.QueueUserWorkItem(
                new System.Threading.WaitCallback(SomeLongTask));
            // Queue another task.  
            System.Threading.ThreadPool.QueueUserWorkItem(
                new System.Threading.WaitCallback(AnotherLongTask));
        }

        private void SomeLongTask(Object state)
        {
            while (true)
            {
                Console.WriteLine("1st task running\n");
                Thread.Sleep(1000);
            } 
        }

        private void AnotherLongTask(Object state)
        {
            // Insert code to perform a long task.  
            while (true)
            {
                Console.WriteLine("2nd task running\n");
                Thread.Sleep(1000);
            }
        }
    }
}
