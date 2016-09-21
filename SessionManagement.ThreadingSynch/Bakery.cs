using System.Collections.Generic;
using System.Threading;

namespace SessionManagement.ThreadingSync
{
    public class Bakery
    {
        private readonly Queue<Donut> donutTray = new Queue<Donut>();

        public Donut GetDonut()
        {
            lock (donutTray)
            {
                while (donutTray.Count == 0)
                {
                    Monitor.Wait(donutTray);
                }

                return donutTray.Dequeue();
            }
        }

        public void AddDonut(Donut[] freshDonuts)
        {
            lock (donutTray)
            {
                foreach (var donut in freshDonuts)
                {
                    donutTray.Enqueue(donut);
                }

                Monitor.PulseAll(donutTray);
            }
        }
    }

    public class Donut
    {
        public Donut()
        {
            Name = "Donut yumm!";
        }
        public string Name { get; set; }
    }
}
