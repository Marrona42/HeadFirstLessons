using System;

namespace DamageCalculator
{
    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage(RollDice(3));
            ArrowDamage arrowDamage = new ArrowDamage(RollDice(1));

            while (true)
            {
                Console.WriteLine("0 fo no magic/flaming, 1 for magic, 2 for flaming, " +
                    "3 for both, anything else to quit: ");
                char key = Console.ReadKey().KeyChar;
                if (key != '0' && key != '1' && key != '2' && key != '3') return;

                Console.WriteLine("\nS for sword, A for arrow, anything else to quit: ");
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

    class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;
        private int roll;
        private bool magic;
        private bool flaming;

        public int Damage { get; private set; }

        /// <summary>
        /// Конструктор, который бросает кубик и вычисляет повреждения при всех значениях
        /// </summary>
        /// <param name="startingRoll"></param>
        public SwordDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }

        /// <summary>
        /// Sets or gets 3d6 roll
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Волшебный меч - true, Не волшебный - false
        /// </summary>
        /// 
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Меч в огне - true, Не в огне - false
        /// </summary>
        /// 
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Вычисляет повреждения в зависимости от заданных параметров и броска кубика
        /// </summary>
        public void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }
    }

    class ArrowDamage
    {
        public const decimal BASE_MULTIPLIER = 0.35M;
        public const decimal FLAME_DAMAGE = 1.25M;
        public const decimal MAGIC_MULTIPLIER = 2.5M;
        private int roll;
        private bool magic;
        private bool flaming;

        public int Damage { get; private set; }

        /// <summary>
        /// Конструктор, который бросает кубик и вычисляет повреждения при всех значениях
        /// </summary>
        /// <param name="startingRoll"></param>
        public ArrowDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }

        /// <summary>
        /// Sets or gets 3d6 roll
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Волшебный меч - true, Не волшебный - false
        /// </summary>
        /// 
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Меч в огне - true, Не в огне - false
        /// </summary>
        /// 
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Вычисляет повреждения в зависимости от заданных параметров и броска кубика
        /// </summary>
        public void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic) baseDamage *= MAGIC_MULTIPLIER;
            if (Flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else Damage = (int)Math.Ceiling(baseDamage);
        }
    }
}