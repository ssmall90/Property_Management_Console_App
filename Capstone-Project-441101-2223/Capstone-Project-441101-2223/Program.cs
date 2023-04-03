// See https://aka.ms/new-console-template for more information
using Capstone_Project_441101_2223;

Console.WriteLine("Hello, World!");

ProjectManager projectManager = new ProjectManager();

Project greenland = new Project(10000, "Land");
Project house = new Project(10000, "Renovation");


projectManager.AddProject(greenland);

projectManager.AddProject(house);

ProjectManagerMenu projectManagerMenu = new ProjectManagerMenu(projectManager);

projectManagerMenu.DisplayMenu();





