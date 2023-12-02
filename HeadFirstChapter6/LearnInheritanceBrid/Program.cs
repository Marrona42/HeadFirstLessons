using System;

namespace LearnInheritanceBrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Bird bird;
                Console.Write("\nPress P for pigeon, O for ostrich, M for Penguin, R for Royal Penguin: ");
                char key = Char.ToUpper(Console.ReadKey().KeyChar);
                if (key == 'P') bird = new Pigeon();
                else if (key == 'O') bird = new Ostrich();
                else if (key == 'M') bird = new Penguin();
                else if (key == 'R') bird = new RoyalPenguin();
                else return;

                Console.WriteLine("\nHow many eggs should if lay? ");
                if (!int.TryParse(Console.ReadLine(), out int numberOfEggs)) return;
                Egg[] eggs = bird.LayEggs(numberOfEggs);
                foreach (Egg egg in eggs)
                {
                    Console.WriteLine(egg.Desctription);
                }
            }
        }
    }

    class Egg
    {
        public double Size { get; private set; }
        public string Color { get; private set; }
        public Egg(double size, string color)
        {
            Size = size;
            Color = color;
        }
        public string Desctription
        {
            get
            {
                return $"A {Size: 0.0}cm {Color} egg";
            }
        }
    }

    class BrokenEgg : Egg
    {
        public BrokenEgg(string color) : base(0, $"broken{color}")
        {
            Console.WriteLine("A bird laid a broken egg");
        }
    }

    class Bird
    {
        public static Random Randomizer = new Random();
        public virtual Egg[] LayEggs(int numberOfEggs)
        {
            return new Egg[0];
        }
    }

    class Pigeon : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                if (Bird.Randomizer.Next(4) == 0)
                {
                    eggs[i] = new BrokenEgg(" red");
                }
                else
                {
                    eggs[i] = new Egg(Bird.Randomizer.NextDouble() * 2 + 1, "white");
                }
            }
            return eggs;
        }
    }

    class Ostrich : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                eggs[i] = new Egg(Bird.Randomizer.NextDouble() + 12, "speckled");
            }
            return eggs;
        }
    }

    class Penguin : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                if (Bird.Randomizer.Next(9) == 0)
                {
                    eggs[i] = new BrokenEgg(" red");
                }
                else
                {
                    eggs[i] = new Egg(Bird.Randomizer.NextDouble() * 2 + 1, "black");
                }
            }
            return eggs;
        }
    }

    class RoyalPenguin : Penguin
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                if (Bird.Randomizer.Next(3) == 0)
                {
                    eggs[i] = new BrokenEgg(" red");
                }
                else
                {
                    eggs[i] = new Egg(Bird.Randomizer.NextDouble() * 2 + 1, "blue");
                }
            }
            return eggs;
        }
    }
}
