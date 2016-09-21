using System;
using System.Threading;

namespace SessionManagement.ThreadingSync
{
    class Program
    {
        private static object locker = new object();

        private static int sum = 0;

        static void Main(string[] args)
        {
            //Create a donut factory
            var people = new int[100];

            var bakery = new Bakery();

            new Thread(() =>
            {
                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine(bakery.GetDonut().Name);
                }
            }).Start();


            for (int i = 0; i < 100; i++)
            {
                var donuts = new Donut[1];
                donuts[0] = new Donut();
                bakery.AddDonut(donuts);
            }


            var threads = new Thread[10];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(AddOne);
                threads[i].Start();
                threads[i] = new Thread(SubstractOne);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine(sum);
        }

        static void AddOne()
        {

            //Monitor.Enter(locker);
            lock (locker)
            {
                int temp = sum;
                temp++;
                Thread.Sleep(1);
                sum = temp;
                Console.WriteLine($"After adding 1 {sum}");
                //Interlocked.Add(ref sum, 2);
            }
            //Monitor.Exit(locker);
        }

        static void SubstractOne()
        {
            lock (locker)
            {
                int temp = sum;
                temp--;
                Thread.Sleep(1);
                sum = temp;
                Console.WriteLine($"After substracting 1 {sum}");
            }
        }
    }
}
