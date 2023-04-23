using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project_441101_2223
{

    public static class MenuExtras
    {


        public static int GetItemInRange(int pMin, int pMax) // Get User Inputs For Menus
        {

            Console.WriteLine();

            if (pMin > pMax)
            {
                throw new Exception($"Minimum value {pMin} cannot be greater than maximum value {pMax}");

            }

            int result;


            do
            {

                Console.WriteLine($"To Select A Menu Option Please Enter A Number Between {pMin} And {pMax} Inclusive.");

                string userInput = Console.ReadLine();

                Console.WriteLine("");

                try
                {
                    result = int.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"{userInput} Is Not A Number");
                    continue;
                }

                if (result >= pMin && result <= pMax)
                {

                    return result;

                }


                Console.WriteLine($"{result} Is Not Between {pMin} And {pMax} Inclusive.");

            } while (true);

        }

        public static string PrintMenu(List<TypeOfEditToProject> pList) // Print Editing Options
        {
            StringBuilder listBuilder = new StringBuilder();

            for (int i = 0; i < pList.Count; i++)
            {
                listBuilder.AppendLine($"{i + 1}: {pList[i]}\r\n");
            }
            listBuilder.AppendLine($"{pList.Count + 1}: Exit");
            return listBuilder.ToString();
        }

        public static string PrintMenuItem(List<MenuItem> pList) //Print Menu Items
        {
            StringBuilder listBuilder = new StringBuilder();

            for (int i = 0; i < pList.Count; i++)
            {
                listBuilder.AppendLine($"{i + 1}: {pList[i].ToString()}\r\n");
            }
            return listBuilder.ToString();
        }

        public static string GetTypeOfProject()  // Get Project Specifications To Instantiate Project
        {


            string projectType;

            Console.Clear();
            Console.WriteLine("Create A New Project \r\n");
            Console.WriteLine("What Type Of Project Do You Want To Add? \r\n\r\nLand(L) or Renovation(R)?");
            do
            {

                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "l" || userInput.ToLower() == "r" || userInput.ToLower() == "land" || userInput.ToLower() =="renovation")
                {
                    projectType = userInput.ToUpper();
                    string projectType1 = userInput.Substring(0, 1).ToUpper();
                    return projectType1;
                }
                else
                {
                    Console.WriteLine("Invalid Input \r\n\r\nPlease Enter 'L' To Add A Land Project Or 'R' To Add A Renovation Project.");

                    continue;
                }
            }
            while (true);


        }

        public static float GetCostOfProject() // Get Initial Purchase Value to Instantiate Project
        {

            Console.WriteLine("What Was The Cost Of The Project?");
            float projectCost;
            do
            {
                string userInput = Console.ReadLine();
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



        public static void ReturnToMainMenu(string pMessage) // Exit Option Back To Main Menu View
        {

            Console.SetCursorPosition(Console.WindowLeft, Console.CursorTop + 3);
            Console.WriteLine(pMessage);
            Console.SetCursorPosition(Console.WindowLeft, Console.CursorTop + 1);
            Console.WriteLine("Press Any Key To Return To The Main Menu");
            Console.ReadKey();
        }

    }


}
