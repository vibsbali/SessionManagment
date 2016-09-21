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
}