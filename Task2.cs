using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTaskCleverens
{
    internal class Task2
    {
        public static class Server
        {
            private static int count = 0;
            private static readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

            private static int GetCount()
            {
                rwLock.EnterReadLock();
                
                try
                {
                    return count;
                }
                finally
                {
                    rwLock.ExitReadLock();
                }
            }

            private static void AddToCount(int value)
            {
                rwLock.EnterWriteLock();

                try
                {
                    count += value;
                }
                finally
                {
                    rwLock.ExitWriteLock();
                }
            }

            public static void ReadLoop(string name)
            {
                for (int i = 0; i < 5; i++)
                {
                    int value = GetCount();
                    Console.WriteLine($"{name} прочитал: {value}");
                    Thread.Sleep(100);
                }
            }

            public static void WriteLoop(string name)
            {
                for (int i = 0; i < 5; i++)
                {
                    AddToCount(1);
                    Console.WriteLine($"{name} увеличил count");
                    Thread.Sleep(200);
                }
            }
        }
    }
}
