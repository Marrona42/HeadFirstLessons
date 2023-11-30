using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOverrideAndVirtual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SafeOwner owner = new SafeOwner();
            Safe safe = new Safe();
            JewelThief jewelThief = new JewelThief();
            jewelThief.OpenSafe(safe,owner);
            Console.ReadKey(true);
        }
    }

    class Safe
    {
        private string contents = "precious jewels";
        private string SafeCombination = "12345";
        public string Open(string combination)
        {
            if (combination == SafeCombination) return contents;
            return "";
        }

        public void PickLock(Locksmith lockpicker)
        {
            lockpicker.Combination = SafeCombination;
        }
    }

    class SafeOwner
    {
        private string valuables = "";
        public void ReceiveContents(string safeContents)
        {
            valuables = safeContents;
            Console.WriteLine($"Thank you for returning my {valuables}!");
        }
    }

    class Locksmith
    {
        public void OpenSafe(Safe safe, SafeOwner owner)
        {
            safe.PickLock(this);
            string safeContents = safe.Open(Combination);
            ReturnContents(safeContents, owner);
        }

        public string Combination { private get; set; }

        protected virtual void ReturnContents(string safeContents, SafeOwner owner)
        {
            owner.ReceiveContents(safeContents);
        }
    }

    class JewelThief : Locksmith
    {
        private string stolenJewels;
        protected void ReturnContents(string SafeContents, SafeOwner owner)
        {
            stolenJewels = SafeContents;
            Console.WriteLine($"I'm stealing the jewels! I stole: {stolenJewels}");
        }
    }
}
