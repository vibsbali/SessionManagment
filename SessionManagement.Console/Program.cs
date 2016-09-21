using System;
using System.Collections.Generic;

namespace SessionManagement.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            short number = -32000;
            var bits = Convert.ToString(number, 2);

            System.Console.WriteLine(bits.Length);
            System.Console.WriteLine(bits);
        }

        private static void Inheritance()
        {
            var frog = new Frog();
            var fish = new Fish();
            var seaFish = new SeaFish();

            var listOfAnimals = new List<Animal>();
            listOfAnimals.Add(frog);
            listOfAnimals.Add(fish);
            listOfAnimals.Add(seaFish);

            foreach (Animal item in listOfAnimals)
            {
                System.Console.WriteLine(item.GetType());
                System.Console.WriteLine(item.SayHello());
            }
        }
    }
}
