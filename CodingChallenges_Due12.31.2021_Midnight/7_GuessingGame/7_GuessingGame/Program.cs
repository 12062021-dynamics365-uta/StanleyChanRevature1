using System;
using System.Collections.Generic;

namespace _7_GuessingGameChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int rand = GetRandomNumber();
            int userGuess;
            List<int> allGuesses = new List<int>();
            bool correct = false, again = false;
            int count = 0;
            do
            {
                userGuess = GetUsersGuess();
                allGuesses.Add(userGuess);
                if (CompareNums(rand, userGuess) == 1)
                    Console.WriteLine("Too low.");
                else if (CompareNums(rand, userGuess) == -1)
                    Console.WriteLine("Too high.");
                else
                    Console.WriteLine("Correct.");
                    correct = true;
                foreach(int g in allGuesses)
                {
                    Console.Write($"{g}, ");
                }
                count++;
                if (correct)
                {
                    again = PlayGameAgain();
                    if (again)
                    {
                        correct = false;
                        count = 0;
                    }
                }
            } while (!correct && count <= 10);

        }

        /// <summary>
        /// This method returns a randomly chosen number between 1 and 100, inclusive.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNumber()
        {
            Random random = new Random(32);
            return random.Next(0, 101);
        }

        /// <summary>
        /// This method gets input from the user, 
        /// verifies that the input is valid and 
        /// returns an int.
        /// </summary>
        /// <returns></returns>
        public static int GetUsersGuess()
        {
            int convertedNumber = -1;
            bool conversionBool = false;

            do
            {
                Console.WriteLine("Guess between 0 and 100 inclusive. You have a total of 10 tries:");
                conversionBool = Int32.TryParse(Console.ReadLine(), out convertedNumber);
                if (!conversionBool || convertedNumber < 0 || convertedNumber > 100)
                {
                    Console.WriteLine("Invalid Input.");
                }
                return convertedNumber;
            } while (convertedNumber == -1);
        }

        /// <summary>
        /// This method will has two int parameters.
        /// It will:
        /// 1) compare the first number to the second number
        /// 2) return -1 if the first number is less than the second number
        /// 3) return 0 if the numbers are equal
        /// 4) return 1 if the first number is greater than the second number
        /// </summary>
        /// <param name="randomNum"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static int CompareNums(int randomNum, int guess)
        {
            if (randomNum > guess)
                return 1;
            else if (randomNum < guess)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// This method offers the user the chance to play again. 
        /// It returns true if they want to play again and false if they do not.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool PlayGameAgain()
        {
            Console.WriteLine("Press 1 to play again, anything else if you don't want to play again.");
            string again = Console.ReadLine();
            if (again == "1")
                return true;
            return false;
           
        }
    }
}
