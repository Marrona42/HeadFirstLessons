using System;
using System.Diagnostics;

namespace DamagerWPF
{
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Random random = new Random();
    //        SwordDamage swordDamage = new SwordDamage();
    //        while (true)
    //        {
    //            Console.WriteLine("0 fo no Magic/flaming, 1 for maigc, 2 for flaming, " +
    //                "3 fo both, anything else to quit: ");
    //            char key = Console.ReadKey().KeyChar;
    //            if (key != '0' && key != '1' && key != '2' && key != '3') return;

    //            int roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
    //            swordDamage.Roll = roll;
    //            swordDamage.SetMagic(key == '1' || key == '3');
    //            swordDamage.SetFlaming(key == '2' || key == '3');

    //            Console.WriteLine("\nRolled " + roll + " for " + swordDamage.Damage + " HP\n");
    //        }
    //    }
    //}

    class SwordDamage
    {
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll;
        private decimal magicMultiplier = 1M;
        private int flamingDamage = 0;
        public int Damage;

        public void CalculateDamage()
        {
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE + flamingDamage;
            Debug.WriteLine($"CalculateDamage finished: {Damage} (roll: {Roll})");
        }

        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                magicMultiplier = 1.75M;
            }
            else
            {
                magicMultiplier = 1M;
            }
            CalculateDamage();
            Debug.WriteLine($"SetMagic finished: {Damage} (roll: {Roll})");
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
            Debug.WriteLine($"SetFlamig finished: {Damage} (roll: {Roll})");
        }
    }
}
