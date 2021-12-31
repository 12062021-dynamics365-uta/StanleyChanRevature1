using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human2 daredevil = new Human2("Matt", "Murdock", 35);
            Human2 spoderman = new Human2("Peter", "Porker", "blue");
            Human2 tonyStank = new Human2("Tony", "Stark", "brown", 53);

            Console.WriteLine(daredevil.AboutMe2());
            Console.WriteLine(spoderman.AboutMe2());
            Console.WriteLine(tonyStank.AboutMe2());

            daredevil.Weight = 250;
            Console.WriteLine(daredevil.Weight);
            daredevil.Weight = 404;
            Console.WriteLine(daredevil.Weight);
        }
    }
}
