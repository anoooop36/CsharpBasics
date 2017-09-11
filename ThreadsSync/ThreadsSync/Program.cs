﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsSync
{
    class MonitorSample
    {
        static void Main(string[] args)
        {
            int result = 0;
            Cell cell = new Cell();
            CellProd prod = new CellProd(cell,20);
            CellCons cons = new CellCons(cell,20);
            Thread producer = new Thread(new ThreadStart(prod.ThreadRun));
            Thread consumer = new Thread(new ThreadStart(cons.ThreadRun));

            try
            {
                producer.Start();
                consumer.Start();
                producer.Join();
                consumer.Join();
            }
            catch (ThreadStateException e)
            {
                Console.WriteLine(e);
                result = 1;
            }
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e);
                result = 1;
            }
            Environment.ExitCode = result;
            Console.ReadKey();
        }
        
    }

    public class CellProd
    {
        Cell cell;
        int quantity = 1;
        public CellProd(Cell box, int request) {
            cell = box;
            quantity = request;
        }
        public void ThreadRun()
        {
            for (int i = 0; i < quantity+1; i++)
            {
                cell.WriteToCell(i);
            }
        }
    }

    public class CellCons
    {
        Cell cell;
        int quantity = 1;
        public CellCons(Cell box, int request)
        {
            cell = box;
            quantity = request;
        }

        public void ThreadRun()
        {
            int valReturned;
            for (int looper = 1; looper <= quantity; looper++)
            {
                valReturned = cell.ReadFromCell();
            }
        }
    }
    

    public class Cell
    {
        int cellContents;
        bool readerFlag = false;

        public int ReadFromCell()
        {
            lock (this)
            {
                if (!readerFlag)
                {
                    try
                    {
                        Monitor.Wait(this);
                    }
                    catch (SynchronizationLockException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ThreadInterruptedException e) {
                        Console.WriteLine(e);
                    }
                }
                Console.WriteLine("Consume: {0}",cellContents);
                readerFlag = false;
                Monitor.Pulse(this); //pulse tells Cell.WriteToCell that Cell.ReadFroCell is done.

            }
            return cellContents;
        }

        public void WriteToCell(int n)
        {
            lock (this)
            {
                if (readerFlag)
                {
                    try
                    {
                        Monitor.Wait(this);
                    }
                    catch (SynchronizationLockException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ThreadInterruptedException e) {
                        Console.WriteLine(e);
                    }
                }
                cellContents = n;
                Console.WriteLine("Produce: {0}",cellContents);
                readerFlag = true;
                Monitor.Pulse(this);
            }
        }
    }
}
