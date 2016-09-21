using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement.Console
{
    public abstract class Animal
    {
        public virtual string SayHello()
        {
            return "My name is Animal";
        }
    }

    public class Frog : Animal
    {
        public override string SayHello()
        {
            return "My name is Frog";
        }
    }

    public class Fish : Animal
    {
        public override string SayHello()
        {
            return "I am fish";
        }
    }

    public class SeaFish : Fish
    {
        public new string SayHello()
        {
            return "I am sea fish";
        }
    }

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
