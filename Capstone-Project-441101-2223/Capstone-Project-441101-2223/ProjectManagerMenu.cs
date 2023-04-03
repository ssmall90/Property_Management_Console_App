using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        public ProjectManagerMenu(ProjectManager manager)
        {
            _manager = manager;
            _menus = new List<MenuItem>();

        }

        public override void DisplayMenu()
        {
            _menus.Clear();
            _menus.Add(new AddNewProjectMenu(_manager));

            if (_manager._projects.Count > 0)
            {
                _menus.Add(new EditExisitingProjectMenu(_manager));
                //_menus.Add(new RemoveExistingProjectMenu(_manager));
            }

            Console.WriteLine(MenuExtras.PrintMenuItem(_menus));

            GenerateSelectedMenu();
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
                    break;
                case 2:
                    _menus[1].AmendProjectList();
                    break;
                case 3:
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

            Project selectedProject = _manager._projects[selectedOption];


            _menu.Add(new TypeOfEditToProject(selectedProject, _manager));
            _menu[0].DisplayMenu();


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



        

    //public class RemoveExistingProjectMenu : MenuItem
    //{
    //        private ProjectManager _manager;
    //        private List<Menu> _menus;



    //        public override string ToString()
    //        {
    //            return "Remove Existing Project";
    //        }

    //        public RemoveExistingProjectMenu()
    //        {

    //            _menus = new List<Menu>();

    //        }

        //}




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
            _menu.Add(new RemovePurchase());
            _menu.Add(new AddSale());
            _menu.Add(new RemoveSale());

            MenuExtras.PrintMenuItem(_menu);

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

        public override void AmendProjectList()
        {

        }
    }

    public class RemovePurchase : MenuItem
    {
        private ProjectManager _manager;

        public override void AmendProjectList()
        {

        }
    }

    public class RemoveSale : MenuItem
    {
        private ProjectManager _manager;

        public override void AmendProjectList()
        {

        }
    }





}