using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inName = GetName();
            Console.WriteLine(GreetFriend(inName));
            double inDbl = GetNumber();
            double inDbl2 = GetNumber();
            int MathChoice = GetAction();
            double outDbl = DoAction(inDbl, inDbl2, MathChoice);
        }

        public static string GetName()
        {
            Console.WriteLine("Gimme ur name");
            return Console.ReadLine();
        }

        public static string GreetFriend(string name)
        {
            return $"Hello, {name}, I don't know who you are.";
        }

        public static double GetNumber()
        {
            double gotDouble = 0;
            bool boo = false;
            do
            {
                Console.WriteLine("Gimme double");
                boo = Double.TryParse(Console.ReadLine(), out gotDouble);
                if (!boo)
                    Console.WriteLine("That ain't it");
            } while (!boo);
            return gotDouble;

        }

        public static int GetAction()
        {
            int gotInt = 0;
            bool boo = false;
            do
            {
                Console.WriteLine("Gimme 1/2/3/4");
                boo = Int32.TryParse(Console.ReadLine(), out gotInt);
                if (!boo || (gotInt < 0 && gotInt > 4))
                    Console.WriteLine("That ain't it");
            } while (!boo || (gotInt < 0 && gotInt > 4));
            return gotInt;
        }

        public static double DoAction(double x, double y, int action)
        {
            try
            {
                switch (action)
                {
                    case 1:
                        return x + y;
                    case 2:
                        return x - y;
                    case 3:
                        return x * y;
                    case 4:
                        return x / y;
                    default:
                        return 0;
                }
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Uh Oh u make stinky");
                return 0;
            }
        }
    }
}
