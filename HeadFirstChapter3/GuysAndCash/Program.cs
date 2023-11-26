using System;

namespace GuysAndCash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pizzazz foxtrot = new Pizzazz() { Zippo = 2 };
            foxtrot.Bamboo(foxtrot.Zippo);
            Pizzazz november = new Pizzazz() { Zippo = 3 };
            Abracadabra tango = new Abracadabra() { Vavavoom = 4 };
            while (tango.Lala(november.Zippo))
            {
                november.Zippo *= -1;
                november.Bamboo(tango.Vavavoom);
                foxtrot.Bamboo(november.Zippo);
                tango.Vavavoom -= foxtrot.Zippo;
            }
            Console.WriteLine("november.Zippo = " + november.Zippo);
            Console.WriteLine("foxtrot.Zippo = " + foxtrot.Zippo);
            Console.WriteLine("tango.Vavavoom = " + tango.Vavavoom);
        }
    }

    class Pizzazz
    {
        public int Zippo;

        public void Bamboo(int eek)
        {
            Zippo += eek;
        }
    }

    class Abracadabra
    {
        public int Vavavoom;

        public bool Lala (int floq)
        {
            if (floq < Vavavoom)
            {
                Vavavoom += floq;
                return true;
            }
            return false;
        }
    }

    class Guy
    {
        public string Name;
        public int Cash;

        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks.");
        }

        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + "isn't a valid amount");
                Console.ReadKey();
                return 0;
            }
            if (amount > Cash)
            {
                Console.WriteLine(Name + " says: I don't have enought cash to give you " + amount);
                Console.ReadKey();
                return 0;
            }
            Cash -= amount;
            return amount;
        }

        public void RecieveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take");
                Console.ReadKey();
            }
            else
            {
                Cash += amount;
            }
        }
    }

    class NotUse
    {
        private void Usless()
        {
            Guy joe = new Guy() { Cash = 50, Name = "Joe" };
            Guy bob = new Guy() { Cash = 100, Name = "Bob" };

            while (true)
            {
                joe.WriteMyInfo();
                bob.WriteMyInfo();

                Console.Write("Enter an amount: ");
                string howMuch = Console.ReadLine();

                if (howMuch == "") return;

                if (int.TryParse(howMuch, out int amount))
                {
                    Console.Write("Who should ggive the cash: ");
                    string whichGuy = Console.ReadLine();
                    if (whichGuy == "Joe")
                    {
                        int cashGiven = joe.GiveCash(amount);
                        bob.RecieveCash(cashGiven);
                    }
                    else if (whichGuy == "Bob")
                    {
                        int cashGiven = bob.GiveCash(amount);
                        joe.RecieveCash(cashGiven);
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Joe' or 'Bob'");
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please enter an amount (or a blank line to exit).");
                }
            }
        }

        private void SecondUseless()
        {
            double odds = .75;
            Random random = new Random();
            Guy player = new Guy() { Cash = 100, Name = "FallenSoul" };

            Console.WriteLine("Welcome to the casino. The odds are " + odds);
            while (player.Cash > 0)
            {
                player.WriteMyInfo();
                Console.Write("How musch do you want to bet: ");
                string howMuch = Console.ReadLine();
                if (int.TryParse(howMuch, out int amount))
                {
                    int pot = player.GiveCash(amount) * 2;
                    if (pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            int winnings = pot;
                            Console.WriteLine("You win " + winnings);
                            player.RecieveCash(winnings);
                            odds -= .30;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Bad luck, you lose.");
                            odds += .05;
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                    Console.ReadKey();
                }
                Console.Clear();
                Console.WriteLine("The odds are " + odds);
            }
            Console.WriteLine("The house always win");
        }
    }

}
