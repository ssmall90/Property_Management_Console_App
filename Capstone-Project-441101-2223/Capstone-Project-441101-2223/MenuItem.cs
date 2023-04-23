using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project_441101_2223
{

    public class TypeOfEditToProject : MenuItem // Select Type Of Edit To Make To A Project
    {
        private List<TypeOfEditToProject> _menu;
        private Project _project;
        private ProjectManager _manager;
        public override void Select()
        {
            Console.Clear();
            Console.WriteLine("Which Of The Following Would You Like To Do? Enter A Corresponding Number");
            _menu.Add(new AddPurchase(_manager, _project));
            _menu.Add(new RemovePurchase(_manager, _project));
            _menu.Add(new AddSale(_manager, _project));
            _menu.Add(new RemoveSale(_manager, _project));

            Console.WriteLine(MenuExtras.PrintMenu(_menu));

            switch (MenuExtras.GetItemInRange(1, _menu.Count +1))
            {
                case 1:
                    _menu[0].Select();

                    break;
                case 2:
                    _menu[1].Select();
                    break;
                case 3:
                    _menu[2].Select();
                    break;
                case 4:
                    _menu[3].Select();
                    break;
                case 5:
                    MenuExtras.ReturnToMainMenu("");
                    break;
            }
        }

        public TypeOfEditToProject(ProjectManager manager, Project project)
        {
            _menu = new List<TypeOfEditToProject>();
            _manager = manager;
            _project = project;
        }
    }

    public class AddPurchase : TypeOfEditToProject 
    {
        private ProjectManager _manager;
        private Project _project;

        public override void Select()
        {
            _project.AddPurchase();
            MenuExtras.ReturnToMainMenu("Your Purchase Has Been Added To Your Chosen Project");

        }

        public override string ToString()
        {
            return "Add Purchase";
        }

        public AddPurchase(ProjectManager manager, Project project) : base(manager, project)
        {
            _manager = manager;
            _project = project;
        }
    }

    public class AddSale : TypeOfEditToProject
    {
        private ProjectManager _manager;
        private Project _project;

        public override void Select()
        {
            _project.AddSales();
            MenuExtras.ReturnToMainMenu("Your Sale Has Been Added To Your Chosen Project");
        }

        public override string ToString()
        {
            return "Add Sale";
        }

        public AddSale(ProjectManager manager, Project project) : base(manager, project)
        {
            _manager = manager;
            _project = project;
        }
    }

    public class RemovePurchase : TypeOfEditToProject
    {
        private ProjectManager _manager;
        private Project _project;
 

        public override void Select()
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

        public RemovePurchase(ProjectManager manager, Project project) : base(manager, project)
        {
            _manager = manager;
            _project = project;
        }
    }

    public class RemoveSale : TypeOfEditToProject
    {
        private ProjectManager _manager;
        private Project _project;

        public override void Select()
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

        public RemoveSale(ProjectManager manager, Project project) : base(manager, project)
        {
            _manager = manager;
            _project = project;
        }
    }
}
