using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomInt = random.Next();
            Console.WriteLine(randomInt);
            int zeroToNine = random.Next(10);
            Console.WriteLine(zeroToNine);
            int dieRoll = random.Next(1, 7);
            Console.WriteLine(dieRoll);

            double randomDouble = random.NextDouble();
            Console.WriteLine(randomDouble * 100);

            Console.WriteLine((float)randomDouble * 100F);
            Console.WriteLine((decimal)randomDouble * 100M);

            int zeroOrOne = random.Next(2);
            bool coinFlip = Convert.ToBoolean(zeroOrOne);
            Console.WriteLine(coinFlip);
        }
    }
}
