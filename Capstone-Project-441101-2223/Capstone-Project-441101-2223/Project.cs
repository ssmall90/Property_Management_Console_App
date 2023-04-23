using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project_441101_2223
{
    public class Project
    {

        private string _type; // project type . land or renovation ? 
        private float _cost;
        private List<float> _purchases; // list of all purchases from a project
        private float _totalPurchases; // total cost of all purchases from a project
        private List<float> _sales; // list of all sales from a project
        private float _totalSales; // total cost of all sales from a project
        private float _refunds; // all refunds from a project
        private float _profits; // all profits from a project



        public int ID { get; private set; } // ID for project

        static int NextID = 201; // Starting ID

        public List<float> Purchases 

        {
            get { return _purchases; }
            private set { _purchases = value; } // cannont fully protect list contents? 

        }


        public List<float> Sales 
        {
            get { return _sales; }
            private set { _sales = value; } // cannont fully protect list contents? 
        }

        public float TotalPurchases // Protected total value of all purchases of a project
        {
            get { return _totalPurchases; }
            protected set { _totalPurchases = value; }

        }

        public float TotalSales // Protected total value of all sales of a project
        {
            get { return _totalSales; }
            protected set { _totalSales = value; }

        }

        public float Profits // Protected value of preofits from a project 
        {
            get { return _profits; }
            protected set { _profits = value; }
        }

        public float Refunds // Protected value of refunds from a project
        {
            get { return _refunds; }
            protected set { _refunds = value; }

        }

        protected string Type // Tyep cannot be altered once object instantiated
        {
            get { return _type; }
            set // Conditions set for project type
            {
                if (value.ToUpper() == "L" || value.ToUpper() == "R")
                {
                    _type = value;
                }
                else
                {
                    throw new Exception("Project Type Must Be Either 'L' OR 'R'.");
                }
            }
        }


        public Project(float pInitialPurchase, string TypeOfProject) : this (pInitialPurchase,TypeOfProject,NextID)
        {
            ID = NextID;
            NextID++;
 
        }

        public Project(float pInitialPurchase, string TypeOfProject, int IDNum)
        {
            ID = IDNum;
            _purchases = new List<float>();
            _sales = new List<float>();
            _cost = pInitialPurchase;
            _purchases.Add(pInitialPurchase);
            _totalPurchases = pInitialPurchase;
            Type = TypeOfProject;
            _type = Type;
            _profits = _totalSales - _totalPurchases;
            _refunds = CalculateTaxRefund(this);
        }

        public void UpdateProject(float valueOfSaleOrPurchase, string saleOrPurchase)   // Update Projects During File Upload
        {

            switch (saleOrPurchase)
            {
                case "S":
                    _sales.Add(valueOfSaleOrPurchase);
                    _totalSales += valueOfSaleOrPurchase;
                    AdjustProfits();
                    break;
                case "SALE":
                    _sales.Add(valueOfSaleOrPurchase);
                    _totalSales += valueOfSaleOrPurchase;
                    AdjustProfits();
                    break;

                case "P":
                    _purchases.Add(valueOfSaleOrPurchase);
                    _totalPurchases += valueOfSaleOrPurchase;
                    AdjustProfits();
                    break;
                case "PURCHASE":
                    _purchases.Add(valueOfSaleOrPurchase);
                    _totalPurchases += valueOfSaleOrPurchase;
                    AdjustProfits();
                    break;

            }



            
        }


        public float AddPurchase() // Add Purchase To A Project
        {
            float costOfPurchase = 0;

            do
            {
                Console.WriteLine("What Was the cost of your most recent purchase?\r\n");

                string userInput = Console.ReadLine();
                try
                {
                    costOfPurchase = float.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"The Number You Have Entered, '{userInput}' Is Not Valid\r\n");
                    continue;
                }

                _purchases.Add(costOfPurchase);
                _totalPurchases += costOfPurchase; // Update Total Purchases
                AdjustProfits();
                Refunds = CalculateTaxRefund(this);

                return costOfPurchase;

            }
            while (true);

        }

        private float AdjustProfits() // Adjust Project Profits
        {
            _profits = TotalSales - TotalPurchases;
            return _profits;
        }

        private float CalculateTaxRefund(Project project) // Calculate Tax
        {
            if (project.Type.ToLower() == "l") // Only Applicable to Land Projects
            {

                float refundValue = TotalPurchases - (TotalPurchases / 1.2f);
                return (float)Math.Round(refundValue, 2);

            }
            else { return 0; }
        }

        public float AddSales() // Add Sale To A Project
        {
            float salePrice = 0;

            do
            {
                Console.WriteLine("What Was The Price Of Your Most Recent Sale?\r\n");

                string userInput = Console.ReadLine();
                try
                {
                    salePrice = float.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"The Number You Have Entered, '{userInput}' Is Not Valid\r\n");
                    continue;
                }

                _sales.Add(salePrice);
                _totalSales += salePrice; // Update Total Sales For Project
                AdjustProfits();

                return salePrice;

            }
            while (true);

        }

        public void RemovePurchase(int purchaseTobeRemoved) // Remove Purchase From A Project
        {
            Profits += _purchases[purchaseTobeRemoved - 1];
            _totalPurchases -= _purchases[purchaseTobeRemoved - 1];
            _purchases.RemoveAt(purchaseTobeRemoved - 1);
            Refunds = CalculateTaxRefund(this);

        }

        public void RemoveSale(int saleToBeRemoved) // Remove Sale From A Project
        {

            _totalSales -= _sales[saleToBeRemoved - 1];
            _sales.RemoveAt(saleToBeRemoved - 1);
            Profits = AdjustProfits();
            Refunds = CalculateTaxRefund(this);

        }

        public override string ToString() // Display Project Info
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("{0,5}{1,10}{2,20}{3,19}{4,19}{5,19}", "ID", "Type", "Total-Purchases", "Total-Sales", "Refunds", "Profits"));
            sb.AppendLine(String.Format("{0,7}{1,9}{2,16}{3,20}{4,21}{5,22}",ID,_type, Math.Round(_totalPurchases,2), Math.Round(_totalSales,2), Math.Round(_refunds, 2), Math.Round(_profits, 2)));

            return sb.ToString();

        }
    }
}
