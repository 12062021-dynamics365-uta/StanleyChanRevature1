using System;
using System.Collections.Generic;

namespace _8_LoopsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Your code here */

        }

        /// <summary>
        /// Return the number of elements in the List<int> that are odd.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseFor(List<int> x)
        {
            int countOdd;
            for(int findOdd = 0; findOdd < x.Count; findOdd++)
            {
                if (x[findOdd] % 2 == 1)
                    countOdd++;
            }
            return countOdd;
            //throw new NotImplementedException("UseFor() is not implemented yet.");
        }

        /// <summary>
        /// This method counts the even entries from the provided List<object> 
        /// and returns the total number found.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForEach(List<object> x)
        {
            int countEven;
            foreach (int findEven in x)
            {
                if (findEven % 2 == 0)
                    countEven++;
            }
            return countEven;
            //throw new NotImplementedException("UseForEach() is not implemented yet.");
        }

        /// <summary>
        /// This method counts the multiples of 4 from the provided List<int>. 
        /// Exit the loop when the integer 1234 is found.
        /// Return the total number of multiples of 4.
        /// </summary>
        /// <param name="x"></param>
        public static int UseWhile(List<int> x)
        {
            int index = 0;
            int countOfFour = 0;
            while (x[index] != 1234)
            {
                if (x[index] % 4 == 0)
                    countOfFour++;
            }
            return countOfFour;
            //throw new NotImplementedException("UseFor() is not implemented yet.");
        }

        /// <summary>
        /// This method will evaluate the Int Array provided and return how many of its 
        /// values are multiples of 3 and 4.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForThreeFour(int[] x)
        {
            int index = 0;
            int count34 = 0;
            do
            {
                if (x[index] % 3 == 0 || x[index] % 4 == 0)
                    count34++;
            } while (index < x.Length);
            return count34;
            //throw new NotImplementedException("UseForThreeFour() is not implemented yet.");
        }

        /// <summary>
        /// This method takes an array of List<string>'s. 
        /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
        /// </summary>
        /// <param name="stringListArray"></param>
        /// <returns></returns>
        public static string LoopdyLoop(List<string>[] stringListArray)
        {
            string toReturn = "";
            foreach(string s in stringListArray)
            {
                toReturn += s + " ";
            }
        }
    }
}