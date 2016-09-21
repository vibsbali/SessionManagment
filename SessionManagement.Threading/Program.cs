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
        static void Main(string[] args)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Main Called");

            var t = new Thread(SayHello);
            //t.IsBackground = true;
            t.Name = "Hello Thread";
            t.Start();

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Main Ended");


            var t2 = new Thread(DisplayMessage);
            t2.Start("Say Hello");


            var messenger = new Messenger("Hello!!");
            var t3 = new Thread(messenger.SayHello);
            t3.Start();
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
                Console.WriteLine(msg);
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
