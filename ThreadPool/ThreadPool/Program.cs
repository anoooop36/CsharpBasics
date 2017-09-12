//Couldn't understand the whole problem.But ThreadPool understood.
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPool
{

    class SimplePool
    {
        public static int Main(string[] args)
        {
            Console.WriteLine("Thread Pool Sample:");
            bool W2K = false;
            int MaxCount = 10;
            ManualResetEvent eventX = new ManualResetEvent(false);
            Console.WriteLine("Queuing {0} items to Thread Pool",MaxCount);
            Alpha alpha = new Alpha(MaxCount);
            alpha.eventX = eventX;
            Console.WriteLine("Queue to Thread Pool 0");
            try
            {
                System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(alpha.Beta), new SomeState(0));
                W2K = true;
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("These api's may fail on non-windows");
                W2K = false;
            }
            if (W2K)
            {
                for (int i = 1; i < MaxCount; i++)
                {
                    Console.WriteLine("Queue to Thread Pool {0}",i);
                    System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(alpha.Beta),new SomeState(i));
                }
                Console.WriteLine("Waiting for Thread Pool to drain");
                eventX.WaitOne(Timeout.Infinite, true);
                Console.WriteLine("Thread Pool has been drained (Eevent fired)");
                Console.WriteLine();
                Console.WriteLine("Load acress threads");
                foreach (object o in alpha.HashCount.Keys)
                    Console.WriteLine("{0} {1}",o,alpha.HashCount[o]);
          
            }
            Console.ReadKey();
            return 0;

        }
    }

    public class SomeState
    {
        public int Cookie;
        public SomeState(int iCookie)
        {
            Cookie = iCookie;
        }
    }

    public class Alpha
    {
        public Hashtable HashCount;
        public ManualResetEvent eventX;
        public static int iCount = 0;
        public static int iMaxCount = 0;
        public Alpha(int MaxCount)
        {
            HashCount = new Hashtable(MaxCount);
            iMaxCount = MaxCount;
        }

        public void Beta(Object state)
        {
            Console.WriteLine(" {0} {1} :",Thread.CurrentThread.GetHashCode(),((SomeState)state).Cookie);
            Console.WriteLine("HashCount.Count=={0}, Thread.CurrentThread.GetHashCode()=={1}",HashCount.Count,Thread.CurrentThread.GetHashCode());
            lock (HashCount)
            {
                if (!HashCount.ContainsKey(Thread.CurrentThread.GetHashCode()))
                {
                    HashCount.Add(Thread.CurrentThread.GetHashCode(), 0);
                }
                HashCount[Thread.CurrentThread.GetHashCode()] = ((int)HashCount[Thread.CurrentThread.GetHashCode()]) + 1;

            }

            int iX = 2000;
            Thread.Sleep(iX);
            Interlocked.Increment(ref iCount);
            if (iCount==iMaxCount)
            {
                Console.WriteLine("\nSetting eventX ");
                eventX.Set();
            }
        }

       



        }

}

