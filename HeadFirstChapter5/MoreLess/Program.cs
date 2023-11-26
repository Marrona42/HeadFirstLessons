using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreLess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HiLo");
            Console.WriteLine($"Guess numbers between 1 and {HiLoGame.MAXIMUM}.");
            HiLoGame.Hint();
            while (HiLoGame.GetPot() > 0)
            {
                Console.WriteLine("Press h for higher, l for lower, ? to buy a hint, ");
                Console.WriteLine($"or any other key to quit with {HiLoGame.GetPot()}.");

                char key = Console.ReadKey().KeyChar;
                if (key == 'h' || key == 'H') HiLoGame.Guess(true);
                else if (key == 'l' || key == 'L') HiLoGame.Guess(false);
                else if (key == '?' || key == '/') HiLoGame.Hint();
                else return;
            }
            Console.WriteLine("The pot is empye. Bye!");
        }
    }

    static class HiLoGame
    {
        public const int MAXIMUM = 10;
        private static Random random = new Random();
        private static int currentNumber = random.Next(1, MAXIMUM + 1);
        private static int pot = 10;

        public static int GetPot()
        {
            return pot;
        }

        public static void Guess(bool higher)
        {
            int nextNumber = random.Next(1, MAXIMUM + 1);
            if ((higher && nextNumber >= currentNumber) || (!higher && nextNumber <= currentNumber))
            {
                Console.WriteLine("You guessed right!");
                pot++;
            }
            else
            {
                Console.WriteLine("Bad luck, you gguessed wrong");
                pot--;
            }
            currentNumber = nextNumber;
            Console.WriteLine($"The current number is {currentNumber}");
        }

        public static void Hint()
        {
            int half = MAXIMUM / 2;
            if(currentNumber >=half)
            {
            Console.WriteLine($"The number is Attribute least {half}");
            }
            else
            {
            Console.WriteLine($"The number is Attribute most {half}");
            }
            pot--;
        }
    }
}
