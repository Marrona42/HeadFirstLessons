using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyElephant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Elephant lucinda = new Elephant() { name = "Lucinda", earSize = 33 };
            Elephant lloyd = new Elephant() { name = "Lloyd", earSize = 40 };

            Console.WriteLine("Press 1 for Lloyd, 2 for Lucinda, 3 to swap");

            while (true)
            {
                char input = Console.ReadKey(true).KeyChar;
                Console.WriteLine("You pressed " + input);

                if (input == '1')
                {
                    Console.WriteLine("Calling lloyud.WhoAmI()");
                    lloyd.WhoAmI();
                }
                else if (input == '2')
                {
                    Console.WriteLine("Calling lucinda.WhoAmI()");
                    lucinda.WhoAmI();
                }
                else if (input == '3')
                {
                    Elephant holder;
                    holder = lloyd;
                    lloyd = lucinda;
                    lucinda = holder;
                    Console.WriteLine("Reference have been swapped");
                }
                else if (input == '5')
                {
                    lucinda.SpeakTo(lloyd, "Hi, Lloyd");
                }
                else return;
                Console.WriteLine();
            }
        }
    }

    public class Elephant
    {
        public string name;
        public int earSize;

        public void WhoAmI()
        {
            Console.WriteLine("My name is " + name);
            Console.WriteLine("My ears are " + earSize + "inches tall.");
        }

        public void HearMessage (string message, Elephant whoSaidIt)
        {
            Console.WriteLine(name + " heard a message");
            Console.WriteLine(whoSaidIt + " said this: " + message);
        }

        public void SpeakTo(Elephant whoToTalkTo, string message)
        {
            whoToTalkTo.HearMessage(message, this);
        }
    }
}
