using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingExercise
{
    public class Mixed5
    {
        public static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            A a2 = new C();

            string q = "";

            q += a2.m1();
            q += a2.m2();
            q += a2.m3();

            Console.WriteLine(q);
        }
    }

    class A
    {
        public int ivar = 7;

        public virtual string m1()
        {
            return "A's m1, ";
        }

        public string m2()
        {
            return "A's m2, ";
        }

        public virtual string m3()
        {
            return "A's m3, ";
        }

    }

    class B : A
    {
        public override string m1()
        {
            return "B's m1, ";
        }
    }

    class C : B
    {
        public override string m3()
        {
            return "C's m3, " + (ivar + 6);
        }
    }
}
