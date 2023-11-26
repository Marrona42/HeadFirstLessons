using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickRandomCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of cars to pick: ");
            string line = Console.ReadLine();

            if (int.TryParse(line, out int numberOfCards))
            {
                foreach (string cards in CardPicker.PickSomeCards(numberOfCards))
                {
                    Console.WriteLine(cards);
                }
            }
            else
            {
                Console.WriteLine("Wrong enter");
            }
        }
    }
}
