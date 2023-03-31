using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project_441101_2223
{

    public abstract class Menu
    {
        public abstract void DisplayMenu();
        public abstract int GetUserInput();
        public abstract void GenerateSelectedMenu();

    }

    public abstract class MenuItem
    {
        public abstract void AmendProjectList();
    }


    public static class MenuExtras
    {
        public static int GetItemInRange(int pMin, int pMax)
        {


            if (pMin > pMax)
            {
                throw new Exception($"Minimum value {pMin} cannot be greater than maximum value {pMax}");
            }

            int result;


            do
            {

                Console.WriteLine($"Please enter a number between {pMin} and {pMax} inclusive.");

                string userInput = Console.ReadLine();

                try
                {
                    result = int.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"{userInput} is not a number");
                    continue;
                }

                if (result >= pMin && result <= pMax)
                {

                    return result;

                }


                Console.WriteLine($"{result} is not between {pMin} and {pMax} inclusive.");

            } while (true);

        }
    }



 



}
