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

        public static string PrintMenu (int pListLength, List<Menu> pList)
        {
            StringBuilder listBuilder = new StringBuilder();

            for (int i = 0; i < pList.Count; i++)
            {
                listBuilder.AppendLine($"{i + 1}: {pList[i]}");
            }
            return listBuilder.ToString();
        }

        public static string PrintMenuItem( List<MenuItem> pList)
        {
            StringBuilder listBuilder = new StringBuilder();

            for (int i = 0; i < pList.Count; i++)
            {
                listBuilder.AppendLine($"{i + 1}: {pList[i]}");
            }
            return listBuilder.ToString();
        }

        public static string GetTypeOfProject()
        {

            Console.Clear();
            Console.WriteLine("What Type Of Project Do You Want To Add? \nLand(L) or Renovation(R)");
            string projectType;
            do
            {
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "l" || userInput.ToLower() == "r")
                {
                    projectType = userInput;
                    return projectType;
                }
                else
                {
                    Console.WriteLine($"Please Enter 'L' To Add A Land Project Or 'R' To Add A Renovation Project.");
                    continue;
                }
            }
            while(true);


        }

        public static float GetCostOfProject()
        {

            Console.WriteLine("What Was The Cost Of The Project?");
            float projectCost;
            do
            {
             string userInput = Console.ReadLine() ;
                try
                {
                    projectCost = int.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine("Please Enter A Valid Value. E.g; 1000");
                    continue;
                }

                return projectCost;
                
            }
            while (true);


        }

    }



 



}
