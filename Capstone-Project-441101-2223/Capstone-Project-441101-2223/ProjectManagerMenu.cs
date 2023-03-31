using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Capstone_Project_441101_2223
{
     public class ProjectManagerMenu: Menu
    {
        private ProjectManager _manager;
        private List<Menu> _menus;

       
        public ProjectManagerMenu(ProjectManager manager) 
        { 
            _manager = manager;
            _menus = new List<Menu>();

        }

            public override void DisplayMenu()
        {
            _menus.Clear();
            _menus.Add(new AddNewProjectMenu(_manager));

            if (_manager.Projects.Count > 0)
            {
                _menus.Add(new EditExisitingProjectMenu(_manager));
                _menus.Add(new RemoveExistingProjectMenu(_manager));
            }

            for (int i = 0; i < _menus.Count ; i++)
            {
                Console.WriteLine($"{i+1}: {_menus[i]}");
            }

            GenerateSelectedMenu();
        }

        public override int GetUserInput() 
        {
           return MenuExtras.GetItemInRange(1, _menus.Count);
        }

        public override void GenerateSelectedMenu()
        {
            switch (GetUserInput())
            {
                case 1:
                    _menus[0].DisplayMenu();
                        break;
                case 2:
                    _menus[1].DisplayMenu();
                    break;
                case 3:
                    _menus[2].DisplayMenu();
                    break;
            }
        }


        public override string ToString()
        {
            return "Project Manager Menu";
        }
    

    public class AddNewProjectMenu : Menu
    {
            private ProjectManager _manager;
            private List<MenuItem> _menus;


            public override void DisplayMenu()
            {
                Console.Clear();
                _menus.Clear();
                _menus.Add(new AddLandProject(_manager));
                _menus.Add(new AddRenovationProject(_manager));

                for (int i = 0; i < _menus.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {_menus[i]}");
                }
                GenerateSelectedMenu();
            }
            public override int GetUserInput()
            {
                return MenuExtras.GetItemInRange(1, _menus.Count);
            }

            public override void GenerateSelectedMenu()
            {
                switch(GetUserInput())
                {
                    case 1:
                        _menus[0].AmendProjectList(); break;
                    case 2:
                        _menus[1].AmendProjectList(); break;

                }
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

    public class EditExisitingProjectMenu :Menu
    {
            private ProjectManager _manager;
            private List<Menu> _menus;


            public override void DisplayMenu() { }
            public override int GetUserInput() { return 1; }

            public override void GenerateSelectedMenu() { }

            public override string ToString()
            { 
                return "Edit Existing Project";
            }


            public EditExisitingProjectMenu(ProjectManager manager)
            {
                _manager = manager;
                _menus = new List<Menu>();

            }
        }

    public class RemoveExistingProjectMenu : Menu
    {
            private ProjectManager _manager;
            private List<Menu> _menus;


            public override void DisplayMenu() { }
            public override int GetUserInput() { return 1; }

            public override void GenerateSelectedMenu() { }

            public override string ToString()
            {
                return "Remove Existing Project";
            }

            public RemoveExistingProjectMenu(ProjectManager manager)
            {
                _manager = manager;
                _menus = new List<Menu>();

            }

        }

        public class AddLandProject : MenuItem
        {
            private ProjectManager _manager;
            private int _price;

            public override void AmendProjectList()
            {
                Console.WriteLine("How Much Was The Land?");
                _price = int.Parse(Console.ReadLine());

                _manager.Projects.Add(new LandProject(_price));
            }

            public override string ToString()
            {
                return "Add Land Project";
            }

            public AddLandProject(ProjectManager manager)
            {
                _manager = manager;

            }
        }



        public class AddRenovationProject : MenuItem
        {
            private ProjectManager _manager;
            private int _price;


            public override void AmendProjectList()
            {
                Console.WriteLine("How Much Was The Propoerty?");
                _price = int.Parse(Console.ReadLine());

                _manager.Projects.Add(new LandProject(_price));
            }
            public override string ToString()
            {
                return "Add Renovation Project";
            }

            public AddRenovationProject(ProjectManager manager)
            {
                _manager = manager;

            }
        }



    }

}