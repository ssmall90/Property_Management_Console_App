using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Capstone_Project_441101_2223
{
    public class ProjectManagerMenu : Menu
    {
        private ProjectManager _manager;
        private List<MenuItem> _menus;
        bool _showMenu;


        public ProjectManagerMenu(ProjectManager manager)
        {
            _manager = manager;
            _menus = new List<MenuItem>();
            

        }

        public override void DisplayMenu()
        {
            _showMenu = true;
            do
            {
                Console.Clear();
                _menus.Clear();
                _menus.Add(new AddNewProjectMenu(_manager));

                if (_manager._projects.Count > 0)
                {
                    _menus.Add(new EditExisitingProjectMenu(_manager));
                    _menus.Add(new RemoveExistingProjectMenu(_manager));
                    _menus.Add(new ViewProjects(_manager));
                    _menus.Add(new ViewPortFolioSummary(_manager));

                }

                Console.WriteLine(MenuExtras.PrintMenuItem(_menus));

                GenerateSelectedMenu();
            }
            while (_showMenu);

        }


        public override int GetUserInput()
        {
            return MenuExtras.GetItemInRange(1, _menus.Count);
        }

        public override void GenerateSelectedMenu()
        {
            string typeOfProject;
            float cost;

            switch (GetUserInput())
            {
                case 1:
                    typeOfProject = MenuExtras.GetTypeOfProject();
                    cost = MenuExtras.GetCostOfProject();
                    _manager._projects.Add(new Project(cost, typeOfProject));
                    MenuExtras.ReturnToMainMenu("Your New Project Has Been Added To Your Porfolio");
                    DisplayMenu();
                    break;
                case 2:
                    _menus[1].AmendProjectList();
                    break;
                case 3:
                    _menus[2].AmendProjectList();
                   break;
                case 4:
                    _menus[3].AmendProjectList();
                    break;
                case 5:
                    _menus[4].AmendProjectList();
                    break;
            }
            
        }


        public override string ToString()
        {
            return "Project Manager Menu";
        }
    }


    public class AddNewProjectMenu : MenuItem
    {
        private ProjectManager _manager;
        private List<MenuItem> _menus;

        public override void AmendProjectList()
        {
            Console.WriteLine("Nothing");
        }

        public override string ToString()
        {
            return "Add New Project";

        }

        public AddNewProjectMenu(ProjectManager manager)
        {
            _manager = manager;
            _menus = new List<MenuItem>();

        }
    }


    public class EditExisitingProjectMenu : MenuItem 
    {
        private ProjectManager _manager;
        private List<Menu> _menu;



        public override void AmendProjectList()
        {

            Console.Clear();
            Console.WriteLine("Which Project Would You Like To Edit?");


            for (int i = 0; i < _manager._projects.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {_manager._projects[i].ToString()}");
                Console.WriteLine();
            }

            int selectedOption = MenuExtras.GetItemInRange(1, _manager._projects.Count);

            Project selectedProject = _manager._projects[selectedOption - 1];


            _menu.Add(new TypeOfEditToProject(selectedProject, _manager));

            _menu[0].DisplayMenu();

            MenuExtras.GoBack(_manager);
        }


        public override string ToString()
        {
            return "Edit Existing Project";
        }

        public EditExisitingProjectMenu(ProjectManager manager)
        {
            _manager = manager;
            _menu = new List<Menu>();

        }
    }

    public class ViewPortFolioSummary: MenuItem
    {
        private ProjectManager _manager;

        public override void AmendProjectList()
        {
            Console.Clear();
            Console.WriteLine("Entire Portfolio Summary");
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);

            float totalOfPurchases = 0 ;
            float totalOfSales= 0 ;
            float totalOfRefunds = 0;
            float totalOfProfit = 0;

            for (int i =0; i < _manager._projects.Count;i++)
            {
                Console.WriteLine($"{i+1} {_manager._projects[i].ToString()}");
                totalOfPurchases += _manager._projects[i].TotalPurchases;
                totalOfSales += _manager._projects[i].TotalSales;
                totalOfRefunds += _manager._projects[i].Refunds;
                totalOfProfit += _manager._projects[i].Profits;
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,7}{1,9}{2,16}{3,20}{4,21}{5,22}","Total", "NA" ,totalOfPurchases, totalOfSales, totalOfRefunds, totalOfProfit);
            Console.SetCursorPosition(Console.WindowLeft, Console.CursorTop + 5);
            Console.WriteLine("Press Any Key To Return To Main Menu");

            Console.ReadKey();
        }

        public override string ToString()
        {
            return "View Portfolio Summary";
        }

        public ViewPortFolioSummary(ProjectManager manager)
        {
            _manager = manager;
        }
    }

    public class ViewProjects : MenuItem
    {
        private ProjectManager _manager;

        public override void AmendProjectList()
        {
            Console.Clear();
            Console.WriteLine("Which Project Would You Like To View?");
            Console.SetCursorPosition(Console.WindowLeft, Console.CursorTop + 2);


            for (int i = 0; i < _manager._projects.Count; i++)
            {
                Console.WriteLine($"{i + 1} {_manager._projects[i].ToString()}");
                Console.WriteLine();
            }

            int selectedOption = MenuExtras.GetItemInRange(1, _manager._projects.Count);

            Project selectedProject = _manager._projects[selectedOption - 1];

            ProjectTableView projectDetails = new ProjectTableView(_manager, selectedProject);

            projectDetails.AmendProjectList();


        }

        public override string ToString()
        {
            return "View A List Of All Your Current Projects";
        }

        public ViewProjects(ProjectManager manager)
        {
            _manager = manager;
        }
    }

    public class ProjectTableView: MenuItem
    {
        private ProjectManager _manager;
        private Project _project;
        private List<float> _purchases;
        private List<float> _sales;

        public override void AmendProjectList()
        {
            Console.Clear();
            Console.WriteLine($"Project {_project.ID} Overview");
            Console.SetCursorPosition(Console.WindowLeft, Console.CursorTop + 2);

            for (int i =0;  i < _project.Purchases.Count; i++)
            {
                Console.WriteLine($"{i+1} {_project.ToString()}");

            }
            Console.SetCursorPosition(Console.WindowLeft, Console.CursorTop + 1);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("List Of All Purchases");
            foreach (var purchase in _project.Purchases)
            {
                sb.AppendLine(purchase.ToString());
            }
            Console.WriteLine(sb.ToString());

            Console.SetCursorPosition(Console.WindowLeft, Console.CursorTop + 1);
            StringBuilder sb2 = new StringBuilder();
            sb2.AppendLine("List Of All Sales");
            foreach (var sale in _project.Sales)
            {
                sb2.AppendLine(sale.ToString());
            }
            Console.WriteLine(sb2.ToString());
            MenuExtras.ReturnToMainMenu("");

        }

        public ProjectTableView(ProjectManager manager, Project project)
        {
            _manager = manager;
            _project = project;
            _purchases = new List<float>();
            _sales = new List<float>();
        }

    }






    public class RemoveExistingProjectMenu : MenuItem
    {
        private ProjectManager _manager;

        public override void AmendProjectList()
        {

            _manager.RemoveProject();
        }


        public override string ToString()
        {
            return "Remove Existing Project";
        }

        public RemoveExistingProjectMenu(ProjectManager manager)
        {

            _manager = manager;       

        }

    }



    public class TypeOfEditToProject : Menu 
    {
        private List<MenuItem> _menu;
        private Project _project;
        private ProjectManager _manager;


        public override void DisplayMenu()
        {

            Console.Clear();
            Console.WriteLine("Which Of The Following Would You Like To Do? Enter A Corresponding Number");
            _menu.Add(new AddPurchase(_manager, _project)); 
            _menu.Add(new RemovePurchase(_manager,_project));
            _menu.Add(new AddSale(_manager, _project));
            _menu.Add(new RemoveSale(_manager,_project));

            Console.WriteLine(MenuExtras.PrintMenuItem(_menu));

            MenuExtras.GoBack(_manager);

            GenerateSelectedMenu();




        }

        public override int GetUserInput()
        {
            return MenuExtras.GetItemInRange(1, _menu.Count);
        }

        public override void GenerateSelectedMenu()
        {

            switch (GetUserInput())
            {
                case 1:
                    _menu[0].AmendProjectList();

                    break;
                case 2:
                    _menu[1].AmendProjectList();
                    break;
                case 3:
                    _menu[2].AmendProjectList();
                    break;
                case 4:
                    _menu[3].AmendProjectList();
                    break;
            }
        }

        public TypeOfEditToProject(Project project, ProjectManager manager)
        {
            _menu = new List<MenuItem>();
            _project = project;
            _manager = manager;
        }

    }

    public class AddPurchase : MenuItem
    {
        private ProjectManager _manager;
        private Project _project;




        public override void AmendProjectList()
        {
            _project.AddPurchase();
            MenuExtras.ReturnToMainMenu("Your Purchase Has Been Added To Your Chosen Project");

        }

        public override string ToString()
        {
            return "Add Purchase";
        }

        public AddPurchase (ProjectManager manager, Project project)
        {
            _manager = manager;
            _project = project;
        }
    }

    public class AddSale : MenuItem
    {
        private ProjectManager _manager;
        private Project _project;

        public override void AmendProjectList()
        {
            _project.AddSales();
            MenuExtras.ReturnToMainMenu("Your Sale Has Been Added To Your Chosen Project");
        }

        public override string ToString()
        {
            return "Add Sale";
        }

        public AddSale(ProjectManager manager, Project project)
        {
            _manager = manager;
            _project = project;
        }
    }

    public class RemovePurchase : MenuItem
    {
        private ProjectManager _manager;
        private Project _project;
        private List<float> _purchases; 

        public override void AmendProjectList()
        {
            if (_project.Purchases.Count > 0)
            {
                int selectedPurchase;
                float purchaseValue;

                Console.WriteLine("Which Purchase Would You Like To Remove?");

                for (int i = 0; i < _project.Purchases.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {_project.Purchases[i].ToString()}");

                }
                selectedPurchase = MenuExtras.GetItemInRange(0, _project.Purchases.Count);

                purchaseValue = _project.Purchases[selectedPurchase - 1];
                _project.RemovePurchase(selectedPurchase);
                MenuExtras.ReturnToMainMenu("Your Purchase Has Been Removed From Your Chosen Project");
            }

            else 
            {
                MenuExtras.ReturnToMainMenu("The Selected Project Does Not Have Any Purchases");    
            }


        }

        public override string ToString()
        {
            return "Remove Purchase";
        }

        public RemovePurchase(ProjectManager manager, Project project)
        {
            _manager = manager;
            _project = project;
        }
    }

    public class RemoveSale : MenuItem
    {
        private ProjectManager _manager;
        private Project _project;

        public override void AmendProjectList()
        {
            if (_project.Sales.Count > 0)
            {
                int selectedSale;
                float saleValue;

                Console.WriteLine("Which Sale Would You Like To Remove?");

                for (int i = 0; i < _project.Sales.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {_project.Sales[i].ToString()}");

                }
                selectedSale = MenuExtras.GetItemInRange(0, _project.Purchases.Count);

                saleValue = _project.Sales[selectedSale - 1];
                _project.RemoveSale(selectedSale);
                MenuExtras.ReturnToMainMenu("Your Sale Has Been Removed From Your Chosen Project");
            }
            else
            {
                MenuExtras.ReturnToMainMenu("The Selected Project Does Not Have Any Sales");
            }

        }

        public override string ToString()
        {
            return "Remove Sale";
        }

        public RemoveSale(ProjectManager manager, Project project)
        {
            _manager = manager;
            _project = project;
        }
    }





}