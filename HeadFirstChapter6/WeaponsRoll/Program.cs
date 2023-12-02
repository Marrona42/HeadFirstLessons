using System;
using System.Security.Cryptography.X509Certificates;

namespace WeaponsRoll
{
    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage(RollDice(3));
            ArrowDamage arrowDamage = new ArrowDamage(RollDice(1));
            MaceDamage maceDamage = new MaceDamage(RollDice(7));

            while (true)
            {
                Console.WriteLine("0 fo no magic/flaming, 1 for magic, 2 for flaming, " +
                    "3 for both, anything else to quit: ");
                char key = Console.ReadKey().KeyChar;
                if (key != '0' && key != '1' && key != '2' && key != '3') return;

                Console.WriteLine("\nS for sword, A for arrow, M for mace, anything else to quit: ");
                char weaponKey = Char.ToUpper(Console.ReadKey().KeyChar);

                switch (weaponKey)
                {
                    case 'S':
                        swordDamage.Roll = RollDice(3);
                        swordDamage.Magic = (key == '1' || key == '3');
                        swordDamage.Flaming = (key == '2' || key == '3');
                        Console.WriteLine($"\nRolled {swordDamage.Roll} for {swordDamage.Damage} HP\n");
                        break;

                    case 'A':
                        arrowDamage.Roll = RollDice(1);
                        arrowDamage.Magic = (key == '1' || key == '3');
                        arrowDamage.Flaming = (key == '2' || key == '3');
                        Console.WriteLine($"\nRolled {arrowDamage.Roll} for {arrowDamage.Damage} HP\n");
                        break;

                    case 'M':
                        maceDamage.Roll = RollDice(7);
                        maceDamage.Magic = (key == '1' || key == '3');
                        maceDamage.Flaming = (key == '2' || key == '3');
                        Console.WriteLine($"\nRolled {maceDamage.Roll} for {maceDamage.Damage} HP\n");
                        break;

                    default:
                        return;
                }

            }
        }

        private static int RollDice(int numberOfRolls)
        {
            int total = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                total += random.Next(1, 7);
            }

            return total;
        }
    }

    class WeaponDamage
    {
        public int Damage { get; protected set; }


        private int roll;
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }


        private bool magic;
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }


        private bool flaming;
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }



        public WeaponDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }

        protected virtual void CalculateDamage() { }

    }

    class SwordDamage : WeaponDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public SwordDamage(int startingRoll) : base(startingRoll) { }

        protected override void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }
    }

    class MaceDamage : WeaponDamage
    {
        public const int BASE_DAMAGE = 5;
        public const int PLUMBER_DAMAGE = 7;

        public MaceDamage(int startingRoll) : base(startingRoll) { }

        protected override void CalculateDamage()
        {
            decimal magicDamage = 1.1M;
            if (Magic) magicDamage = 0.9M;

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicDamage) + BASE_DAMAGE;
            if (Flaming) Damage += PLUMBER_DAMAGE;
        }
    }

    class ArrowDamage : WeaponDamage
    {
        public const decimal BASE_MULTIPLIER = 0.35M;
        public const decimal FLAME_DAMAGE = 1.25M;
        public const decimal MAGIC_MULTIPLIER = 2.5M;

        public ArrowDamage(int startingRoll) : base(startingRoll) { }

        protected override void CalculateDamage()
        {
            decimal baseDamage = Roll * MAGIC_MULTIPLIER;
            if (Magic) baseDamage *= MAGIC_MULTIPLIER;
            if (Flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else Damage = (int)Math.Ceiling(baseDamage);
        }
    }
}