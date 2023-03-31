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
        public List<Project> Projects { get; private set; }

        public ProjectManager()
        {
            Projects = new List<Project>();
        }

        public void AddProject(Project pProject)
        {
            Projects.Add(pProject);
        }

    }
    public abstract class Project
    {

        public int ID { get; private set; } // ID for all projects 

        static int NextID;

        public Project()
        {
            ID = NextID;
            NextID++;
        }


    }

    public class LandProject : Project
    {

        private float Purchases;
        private float Sales;
        private float Refunds;
        private float Profits;

        public float purchases
        {
            get { return Purchases; }
            set { if (value > 0) { Purchases = value; } else { Console.WriteLine("Cost of project must be above 0"); } }

        }

        public float sales
        {
            get { return Sales; }private set { }

        }

        public float refunds
        {
            get { return Refunds; }private set { }

        }

        public float profits
        {
            get { return Profits; }private set { }

        }

        public LandProject(float pCostOfLand)
        {
            purchases = pCostOfLand;
            
        }

        public override string ToString()
        {
            return $"Purchases: {Purchases} \n Sales:{Sales} \n Refunds:{Refunds} \n Profits:{Profits}.";
        }

    }

    public class RenovationProject : Project
    {

        private float Purchases;
        private float Sales;
        private float Refunds;
        private float Profits;

        public float purchases
        {
            get { return Purchases; }
            set { if (value > 0) { Purchases = value; } else { Console.WriteLine("Cost of project must be above 0"); } }

        }
        public float sales
        {
            get { return Sales; }private set { }

        }
        public float refunds
        {
            get { return Refunds; }private set { }

        }

        public float profits
        {
            get { return Profits; } private set { }

        }

        public RenovationProject(float pCostOfProperty)
        {
            purchases = pCostOfProperty;
        }

        public override string ToString()
        {
            return $"Purchases: {Purchases} \n Sales:{Sales} \n Refunds:{Refunds} \n Profits:{Profits}.";
        }
    }
}
