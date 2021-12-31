using System;

namespace _6_FlowControl
{
    public class Program
    {
        public string uName, pWord;

        static void Main(string[] args)
        {
            int userTemp = GetValidTemperature();
            GiveActivityAdvice(userTemp);

        }

        /// <summary>
        /// This method gets a valid temperature between -40 asnd 135 inclusive from the user
        /// and returns the valid int. 
        /// </summary>
        /// <returns></returns>
        public static int GetValidTemperature()
        {
            int gotInt = 0;
            bool boo = false;
            do
            {
                Console.WriteLine("Gimme temp(-40 to 135)");
                boo = Int32.TryParse(Console.ReadLine(), out gotInt);
                if (!boo || (gotInt < -40 && gotInt > 135))
                    Console.WriteLine("That ain't it");
            } while (!boo || (gotInt < -40 && gotInt > 135));
            return gotInt;
        }

        /// <summary>
        /// This method has one int parameter
        /// It prints outdoor activity advice and temperature opinion to the console 
        /// based on 20 degree increments starting at -20 and ending at 135 
        /// n < -20, Console.Write("hella cold");
        /// -20 <= n < 0, Console.Write("pretty cold");
        ///  0 <= n < 20, Console.Write("cold");
        /// 20 <= n < 40, Console.Write("thawed out");
        /// 40 <= n < 60, Console.Write("feels like Autumn");
        /// 60 <= n < 80, Console.Write("perfect outdoor workout temperature");
        /// 80 <= n < 90, Console.Write("niiice");
        /// 90 <= n < 100, Console.Write("hella hot");
        /// 100 <= n < 135, Console.Write("hottest");
        /// </summary>
        /// <param name="temp"></param>
        public static void GiveActivityAdvice(int temp)
        {
            if (temp < -20)
                Console.Write("hella cold");
            if (0 <= temp < 20)
                Console.Write("cold");
            if (20 <= temp < 40)
                Console.Write("thawed out");
            if (40 <= temp < 60) 
                Console.Write("feels like Autumn");
            if (60 <= temp < 80) 
                Console.Write("perfect outdoor workout temperature");
            if (80 <= temp < 90) 
                Console.Write("niiice");
            if (90 <= temp < 100) 
                Console.Write("hella hot");
            if (100 <= temp <= 135) 
                Console.Write("hottest");

            throw new NotImplementedException($"GiveActivityAdvice() has not been implemented.");
        }

        /// <summary>
        /// This method gets a username and password from the user
        /// and stores that data in the global variables of the 
        /// names in the method.
        /// </summary>
        public static void Register()
        {
            Console.WriteLine("Enter username:");
            uName = Console.ReadLine();
            Console.WriteLine("Enter password:")
            pWord = Console.ReadLine();
            throw new NotImplementedException($"Register() has not been implemented.");
        }

        /// <summary>
        /// This method gets username and password from the user and
        /// compares them with the username and password names provided in Register().
        /// If the password and username match, the method returns true. 
        /// If they do not match, the user is reprompted for the username and password
        /// until the exact matches are inputted.
        /// </summary>
        /// <returns></returns>
        public static bool Login()
        {
            bool match = false;
            string loginUserName;
            string loginPassword;
            do
            {
                Console.WriteLine("Enter username:");
                loginUserName = Console.ReadLine();
                Console.WriteLine("Enter password:")
                loginPassword = Console.ReadLine();
                if (loginUserName == uName && loginPassword == pWord)
                    match = true;
                else
                    Console.WriteLine("No match, try again");
            } while (loginUserName != uName && loginPassword != pWord);
            return match;

            throw new NotImplementedException($"Login() has not been implemented.");
        }

        /// <summary>
        /// This method has one int parameter.
        /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
        /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
        /// or > 78, Console.WriteLine($"{temp} is too hot!");
        /// For each temperature range, a different advice is given. 
        /// </summary>
        /// <param name="temp"></param>
        public static void GetTemperatureTernary(int temp)
        {
            if(temp<=42)
                Console.WriteLine($"{temp} is too cold!");
            else if (temp >= 43 && temp <= 78)
                Console.WriteLine($"{temp} is an ok temperature");
            else
                Console.WriteLine($"{temp} is too hot!");
        }
    }//EoP
}//EoN
