using System;

namespace MyFirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TryAnIf();
            TrySomeLoops();
            TryAnIfElse();
        }

        private static void TryAnIfElse()
        {
            int someValue = 4;
            string name = "Bobo Jr.";

            if((someValue == 3) && (name == "Joe"))
            {
                Console.WriteLine("x is 3 and the name is Joe");
            }
            Console.WriteLine("this line runs no matter what");
        }

        private static void TrySomeLoops()
        {
            int x = 5;
            if (x == 10)
            {
                Console.WriteLine("x mus be 10");
            }
            else
            {
                Console.WriteLine("x isn't 10");
            }
        }

        private static void TryAnIf()
        {
            int count = 0;
            while (count < 10)
            {
                count = count + 1;
            }
            for (int i = 0; i < 5; i++)
            {
                count = count - 1;
            }
            Console.WriteLine("The answer is " + count);    
        }
    }
} 
