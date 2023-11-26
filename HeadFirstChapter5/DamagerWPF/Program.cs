using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;

namespace DamagerWPF
{
    internal class Program
    {
        static Random random = new Random();

        //static void Main(string[] args)
        //{
        //    SwordDamage swordDamage = new SwordDamage(RollDice());

        //    while (true)
        //    {
        //        Console.WriteLine("0 fo no magic/flaming, 1 for magic, 2 for flaming, " +
        //            "3 for both, anything else to quit: ");
        //        char key = Console.ReadKey().KeyChar;
        //        if (key != '0' && key != '1' && key != '2' && key != '3') return;
        //        swordDamage.Roll = RollDice();
        //        swordDamage.Magic = (key == '1' || key == '3');
        //        swordDamage.Flaming = (key == '2' || key == '3');
        //        Console.WriteLine($"\nRolled {swordDamage.Roll} for {swordDamage.Damage} HP\n");
        //    }
        //}

        private static int RollDice()
        {
            return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
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
}
