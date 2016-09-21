using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SessionManagement.Threading
{
    class Program
    {
        private static volatile bool cancel = false;
        static void Main(string[] args)
        {
            /*
                Coordinating Thread Shutdown
            */
            var coordinatedThread = new Thread(SayHelloInfinity);
            coordinatedThread.Start();

            Console.WriteLine("Press ENTER to cancel");
            Console.ReadLine();
            cancel = true;
            //join is important to ensure we allow the thread to do what it is doing before returning
            coordinatedThread.Join();
            Console.WriteLine(coordinatedThread.IsAlive);
            
            //You will have to abort if you do not use Join otherwise we can start the thread again  
            //coordinatedThread.Abort();

            ThreadPool.QueueUserWorkItem(DisplayMessage, "This is from thread pool");

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Main Called");

            var t = new Thread(SayHello);
            //t.IsBackground = true;
            t.Name = "Hello Thread";
            t.Start();

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Main Ended");

            //cancel = false;

            var t2 = new Thread(DisplayMessage);
            t2.Start("Say Hello");

            Console.WriteLine(coordinatedThread.IsAlive);

            var messenger = new Messenger("Hello!!");
            var t3 = new Thread(messenger.SayHello);
            t3.Start();
        }

        private static void SayHelloInfinity()
        {
            while (!cancel)
            {
                Console.WriteLine("Hello");
                Thread.Sleep(1000);
            }
        }

        static void SayHello()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Hello thread Id");
            }
        }

        static void DisplayMessage(object message)
        {
            var msg = message as string;

            if (msg != null)
            {
                Console.WriteLine(msg  + $" from {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }

    //Alternative to Display Message
    public class Messenger
    {
        public string Message { get; private set; }
        public Messenger(string message)
        {
            Message = message;
        }

        public void SayHello()
        {
            Console.WriteLine(Message);
        }
    }
}
