using System.Collections.Generic;
using System.Threading;

namespace Lab_8
{
    class Program
    {
        static List<int> list = new List<int>();
        static object lock1 = new object();
        static object lock2 = new object();

        static void Main(string[] args)
        {
            bai1();
            bai2();
        }

        static void bai1()
        {
            Thread thread1 = new Thread(Thread1);
            Thread thread2 = new Thread(Thread2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        static void bai2()
        {
            Thread thread1 = new Thread(Thread1FunctionLab8);
            Thread thread2 = new Thread(Thread2FunctionLab8);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }

        static void Thread1()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int randomNumber = random.Next(1, 11);
                list.Add(randomNumber);
                Thread.Sleep(2000);
            }
        }

        static void Thread2()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                if (list.Count <= 0) return;
                int randomNumber = random.Next(0, list.Count);
                Console.WriteLine("Square of {0} is {1}", list[randomNumber], Math.Pow(list[randomNumber], 2));
            }
        }


        static void Thread1FunctionLab8()
        {
            bool lockTaken1 = false;
            bool lockTaken2 = false;
            Monitor.TryEnter(lock1, TimeSpan.FromSeconds(1), ref lockTaken1);
            if (lockTaken1)
            {
                Console.WriteLine("Thread 1 locked lock1");
                Thread.Sleep(100);
                Console.WriteLine("Thread 1 is waiting for lock2");
                Monitor.TryEnter(lock2, TimeSpan.FromSeconds(1), ref lockTaken2);
                if (lockTaken2)
                {
                    Console.WriteLine("Thread 1 locked lock2");
                }
            }
        }
        static void Thread2FunctionLab8()
        {
            bool lockTaken1 = false;
            bool lockTaken2 = false;

            Monitor.TryEnter(lock2, TimeSpan.FromSeconds(1), ref lockTaken2);
            if (lockTaken2)
            {
                Console.WriteLine("Thread 2 locked lock2");
                Thread.Sleep(100);
                Console.WriteLine("Thread 2 is waiting for lock1");
                Monitor.TryEnter(lock1, TimeSpan.FromSeconds(1), ref lockTaken1);
                if (lockTaken1)
                {
                    Console.WriteLine("Thread 2 locked lock1");
                }
            }
        }
    }
}
