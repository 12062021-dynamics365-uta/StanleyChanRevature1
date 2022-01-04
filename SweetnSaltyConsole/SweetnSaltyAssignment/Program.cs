using System;

namespace SweetnSaltyAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int countSweet = 0, countSalty = 0, countSnS = 0; //initialize count variables to be incremented
            for(int index = 1; index <= 1000; index++) //for loop 1 to 1000 inclusive
            {
                if (index % 3 == 0 && index % 5 == 0) //multiples of 3 and 5
                {
                    Console.Write("sweet'nSalty");
                    countSnS++;
                }
                else if (index % 3 == 0) //multiples of 3
                {
                    Console.Write("sweet");
                    countSweet++;
                }
                else if (index % 5 == 0) //multiples of 5
                {
                    Console.Write("salty");
                    countSalty++;
                }
                else
                    Console.Write(index); //everything else
                if (index % 20 == 0)
                    Console.Write("\n");
                Console.Write(" ");     //I could've implemented the space in each Write but this makes it cleaner if I want more than one space in b/n
            }
            Console.WriteLine($"\nSweet: {countSweet}\nSalty: {countSalty}\nSweet'nSalty: {countSnS}");
        }
    }
}
