# 441101-2223-capstone-project-template

## Encapsulation 
Encapsulation was used throughout the project to ensure the integrity of class members. This is most evident in the 'Project' Class seen below.

```cs
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
            set // Conditions set for project type. 
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
```
All the class members are set to private. Properties have been created to ensure conditions are met before the value of a 
member variable is altered. Access to properties have been set to protected, allowing them to be accessed by class methods
but not by any other part of the program. 


## Inheritence 
Inheritance was used throughout the project. This is most evident in the 'Menu Item' Class seen below. 

```cs

    
        public class TypeOfEditToProject : MenuItem 
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
```
In the code above. The 'TypeOfEditToProject' is a child class of the 'Menu Item' class and the 'Add Purchase' class is derived from the 'TypeOfEditToProject' class. 

## Abstraction 
The project has one abstract class implemented. This is the 'Menu Item' class and can be seen in the code snippet below. 

```cs
    public abstract class MenuItem
    {
        public abstract void Select();

        public MenuItem ()
        {

        }

    }
```

## Polymorphism 
The Abstract method 'Select' in the 'Menu Item' class above is overridden throuhout the code. An example of this can be seen below. 

```cs
    public class EditExsistingProject : MenuItem
    {
        private ProjectManager _manager;
        private List<MenuItem> _menus;
        public override void Select()
        {
            Console.Clear();
            Console.WriteLine("Which Project Would You Like To Edit?\r\n");


            for (int i = 0; i < _manager._projects.Count; i++)  //Print List of Projects
            {
                Console.WriteLine($"{i + 1}: {_manager._projects[i].ToString()}");

                Console.WriteLine("------------------------------------------------------------------------------------------------");
            }

            Console.WriteLine($"{_manager._projects.Count + 1}. Exit"); // Print Exit Option

            int selectedOption = MenuExtras.GetItemInRange(1, _manager._projects.Count + 1); // Get users selected project

            if ( selectedOption <= _manager._projects.Count)
            {
                Project selectedProject = _manager._projects[selectedOption - 1]; 

                _menus.Add(new TypeOfEditToProject(_manager, selectedProject)); // Pass selected project to new type of edit menu item

                _menus[0].Select();
            }

            else
            {
                MenuExtras.ReturnToMainMenu("");
            }

        }

        public override string ToString()
        {
            return "Edit Existing Project";
        }

        public EditExsistingProject(ProjectManager manager)
        {
            _manager = manager;
            _menus = new List<MenuItem>();
        }
    }
```

## Source Control
During the project source control was used. Updates to the project were commited to github at multiple checkpoints. The code for the project has 
comments throughout. Unfortunatley I did not realise that source control was an element we was being marked on untill the majority of the project 
was completed. Due to this , I have not clearly logged my the specific updates that was actually made along the process. 

## User Interaction

An example of consideration for user interaction can be seen in the code snippet below. 
```cs
    public class RemoveExsisitingProject : MenuItem 
    {
        private ProjectManager _manager;
        private List<MenuItem> _menus;
        public override void Select() // Remove Project
        {
            Console.Clear();
            
            Console.WriteLine("Which Project Would You Like To Remove\r\n");

            for (int i = 0; i < _manager._projects.Count; i++)
            {
                Console.WriteLine($"{i + 1} {_manager._projects[i]}");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
            }

            Console.WriteLine($"{ _manager._projects.Count + 1}. Exit"); // Exit Option Incoorporated 

            int selectedProject = MenuExtras.GetItemInRange(1, _manager._projects.Count + 1);

            if ( selectedProject <=  _manager._projects.Count ) 
            {
                _manager._projects.RemoveAt(selectedProject - 1);
                MenuExtras.ReturnToMainMenu("The Selected Project Was Removed From Your Portfolio");
            }

            else
            {
                MenuExtras.ReturnToMainMenu("");
            }

```

Initially the method in this code would not offer the user an option to exit the screen. This meant that once comminted to this method a project 
had to be deleted in order to continue. I incoorporated an exit option to the bottom of the options on the menu. 

## File Loading

The code below shows 1 example of how attempts were made to ensure robustness of the file loading process of the application. 

```cs
         public void UploadFile() // Upload A File
        {
            bool isValid = false;
            do
            {
                Console.WriteLine("Please Enter Enter The Name Of The .txt or .tml File You Want To Upload To The System");
                string userInput = Console.ReadLine();
                Console.WriteLine("");
                try // Check File Has '.' Extension
                {
                    string testData = userInput.Split('.')[1];

                }
                catch
                {
                    Console.WriteLine("File Not Valid. \r\n\r\nPlease Ensure You Enter The Full File Name E.g. 'file.txt', 'file.tml'");
                    Console.WriteLine();
                    continue;
                }
                switch (userInput.Split('.')[1]) // Confirm If File Is TXT or TML
                {
                    case "txt":
                        GetCSVFile(userInput);
                        isValid = true;
                        break;
                    case "tml":
                        GetTMLFile(userInput);
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("File Type Invalid");
                        Console.WriteLine() ;
                        break;
                }
            }
            while (!isValid);
        }
```
The code above shows the intial check on the file inputted. This check ensures that the file name entered by the user has the correct file extension. 

