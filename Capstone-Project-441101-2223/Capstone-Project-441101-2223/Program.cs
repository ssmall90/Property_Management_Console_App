// See https://aka.ms/new-console-template for more information
using Capstone_Project_441101_2223;

Console.WriteLine("Hello, World!");

ProjectManager projectManager = new ProjectManager();

LandProject greenland = new LandProject(5000);

RenovationProject house = new RenovationProject(10000);

projectManager.AddProject(greenland);

projectManager.AddProject(house);

ProjectManagerMenu projectManagerMenu = new ProjectManagerMenu(projectManager);

projectManagerMenu.DisplayMenu();





