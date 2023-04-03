using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project_441101_2223
{
    public class ProjectManager
    {
        public List<Project> _projects;

        public ProjectManager()
        {
            _projects = new List<Project>();

        }

        public void AddProject(Project project)
        {
            _projects.Add(project);
        }

        public void ReturnToMainMenu()
        {
            
        }

    }
    public class Project
    {
        private string _type;
        private float _cost;
        private List<float> _purchases;
        private List<float> _sales;
        private float _refunds;
        private float _profits;


        public int ID { get; private set; } // ID for all projects 

        static int NextID;

        public Project(float pInitialPurchase, string TypeOfProject)
        {
            ID = NextID;
            NextID++;
            _purchases = new List<float>();
            _sales = new List<float>();
            _cost = pInitialPurchase;
            _purchases.Add(pInitialPurchase);
            _type = TypeOfProject;

        }

        public float AddPurchase()
        {
            float costOfPurchase = 0;

            do
            {
                Console.WriteLine("What Was the cost of your most recent purchase?");

                string userInput = Console.ReadLine();
                try
                {
                    costOfPurchase = float.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"The Number You Have Entered, '{userInput}' Is Not Valid");
                    continue;
                }

                _purchases.Add(costOfPurchase);
                return costOfPurchase;

            }
            while (true);

        }

        public float AddSales() 
        {
            float salePrice = 0;

            do
            {
                Console.WriteLine("What Was The Price Of Your Most Recent Sale?");

                string userInput = Console.ReadLine();
                try
                {
                    salePrice = float.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"The Number You Have Entered, '{userInput}' Is Not Valid");
                    continue;
                }

                _sales.Add(salePrice);
                return salePrice;

            }
            while (true);

        }

        public override string ToString()
        {
            return $"ID: {ID} \n TypeOfProject: {_type} \n Purchases: {_purchases} \n Sales:{_sales} \n Refunds:{_refunds} \n Profits:{_profits}.";
        }


    }

    //public class LandProject : Project
    //{
    //    private float _cost;
    //    private List<float> _purchases;
    //    private List<float> _sales;
    //    private float _refunds;
    //    private float _profits;
 


    //    public float refunds
    //    {
    //        get { return _refunds; }private set { }

    //    }

    //    public float profits
    //    {
    //        get { return _profits; }private set { }

    //    }

    //    public LandProject(float pCostOfLand)
    //    {
    //        _cost = pCostOfLand;
    //        _purchases = new List<float>();
    //        _sales = new List<float>();
    //        _purchases.Add(_cost);

    //    }

    //    public override string ToString()
    //    {
    //        return $"Purchases: {_purchases} \n Sales:{_sales} \n Refunds:{_refunds} \n Profits:{_profits}.";
    //    }

    //}

    //public class RenovationProject : Project
    //{

    //    private float _cost;
    //    private List<float> _purchases;
    //    private List<float> _sales;
    //    private float _refunds;
    //    private float _profits;


    //    public float refunds
    //    {
    //        get { return _refunds; }private set { }

    //    }

    //    public float profits
    //    {
    //        get { return _profits; } private set { }

    //    }

    //    public RenovationProject(float pCostOfProperty)
    //    {
    //        _cost = pCostOfProperty;
    //        _purchases = new List<float>();
    //        _sales = new List<float>();
    //        _purchases.Add(_cost);
    //    }

    //    public override string ToString()
    //    {
    //        return $"Purchases: {_purchases} \n Sales:{_sales} \n Refunds:{_refunds} \n Profits:{_profits}.";
    //    }

        
    //}
}
