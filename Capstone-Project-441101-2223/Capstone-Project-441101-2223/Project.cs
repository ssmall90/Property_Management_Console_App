using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project_441101_2223
{
    public class Project
    {

        private string _type;
        private float _cost;
        private List<float> _purchases;
        private float _totalPurchases;
        private List<float> _sales;
        private float _totalSales;
        private float _refunds;
        private float _profits;



        public int ID { get; private set; } // ID for all projects 

        static int NextID = 10101;

        public List<float> Purchases
        {
            get { return _purchases; }
        }

        public List<float> Sales
        {
            get { return _sales; }
        }

        public float TotalPurchases
        {
            get { return _totalPurchases; }
            protected set { _totalPurchases = value; }

        }

        public float TotalSales
        {
            get { return _totalSales; }
            protected set { _totalSales = value; }

        }

        public float Profits
        {
            get { return _profits; }
            protected set { _profits = value; }
        }

        public float Refunds
        {
            get { return _refunds; }
            protected set { _refunds = value; }

        }

        public string Type { get { return _type; } }


        public Project(float pInitialPurchase, string TypeOfProject) : this (pInitialPurchase,TypeOfProject,NextID)
        {
            ID = NextID;
            NextID++;
 
        }

        public Project(float pInitialPurchase, string TypeOfProject, int IDNum)
        {
            ID = IDNum;
            NextID = IDNum;
            _purchases = new List<float>();
            _sales = new List<float>();
            _cost = pInitialPurchase;
            _purchases.Add(pInitialPurchase);
            _totalPurchases = pInitialPurchase;
            _type = TypeOfProject;
            _profits = _totalSales - _totalPurchases;
            _refunds = CalculateTaxRefund(this);
        }

        public void UpdateProject(float valueOfSaleOrPurchase, string saleOrPurchase)
        {
            switch (saleOrPurchase)
            {
                case "S":
                    _sales.Add(valueOfSaleOrPurchase);
                    _totalSales += valueOfSaleOrPurchase;
                    AdjustProfits();
                    break;

                case "P":
                    _purchases.Add(valueOfSaleOrPurchase);
                    _totalPurchases += valueOfSaleOrPurchase;
                    AdjustProfits();
                    break;
            }



            
        }


        public float AddPurchase()
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
                _totalPurchases += costOfPurchase;
                AdjustProfits();
                Refunds = CalculateTaxRefund(this);

                return costOfPurchase;

            }
            while (true);

        }

        public float AdjustProfits()
        {
            _profits = TotalSales - TotalPurchases;
            return _profits;
        }

        public float CalculateTaxRefund(Project project)
        {
            if (project.Type.ToLower() == "l")
            {

                float refundValue = TotalPurchases - (TotalPurchases / 1.2f);
                return (float)Math.Round(refundValue, 2);

            }
            else { return 0; }
        }

        public float AddSales()
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
                _totalSales += salePrice;
                AdjustProfits();

                return salePrice;

            }
            while (true);

        }

        public void RemovePurchase(int purchaseTobeRemoved)
        {
            Profits += _purchases[purchaseTobeRemoved - 1];
            _totalPurchases -= _purchases[purchaseTobeRemoved - 1];
            _purchases.RemoveAt(purchaseTobeRemoved - 1);
            Refunds = CalculateTaxRefund(this);

        }

        public void RemoveSale(int saleToBeRemoved)
        {

            _totalSales -= _sales[saleToBeRemoved - 1];
            _sales.RemoveAt(saleToBeRemoved - 1);
            Profits = AdjustProfits();
            Refunds = CalculateTaxRefund(this);

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("{0,5}{1,10}{2,20}{3,19}{4,19}{5,19}", "ID", "Type", "Total-Purchases", "Total-Sales", "Refunds", "Profits"));
            sb.AppendLine(String.Format("{0,7}{1,9}{2,16}{3,20}{4,21}{5,22}", ID, _type, _totalPurchases, _totalSales, _refunds, _profits));

            return sb.ToString();

        }
    }
}
