using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();

            while (true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DivieBy = RaeadDouble(calculator.DivieBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();

                Console.WriteLine("Calculated ability score: " + calculator.Score);
                Console.WriteLine("Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }
        }


        static double RaeadDouble(double lastUsedValue, string prompt)
        {
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string line = Console.ReadLine();

            if (double.TryParse(line, out double value))
            {
                Console.WriteLine("  using value " + value);
                return value;
            }
            else
            {
                Console.WriteLine(" using default value " + lastUsedValue);
                return lastUsedValue;
            }
        }

        static int ReadInt(int lastUsedValue, string prompt)
        {
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string line = Console.ReadLine();

            if (int.TryParse(line, out int value))
            {
                Console.WriteLine("  using value " + value);
                return value;
            }
            else
            {
                Console.WriteLine(" using default value " + lastUsedValue);
                return lastUsedValue;
            }
        }
    }

    class AbilityScoreCalculator
    {
        public int RollResult = 14;
        public double DivieBy = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public int Score;

        public void CalculateAbilityScore()
        {
            double divided = RollResult / DivieBy;

            int added = AddAmount + (int)divided;

            if (added < Minimum)
            {
                Score = Minimum;
            }
            else
            {
                Score = added;
            }
        }
    }
}



