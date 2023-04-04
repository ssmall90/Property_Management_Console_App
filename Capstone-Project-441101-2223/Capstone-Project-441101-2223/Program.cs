// See https://aka.ms/new-console-template for more information
using Capstone_Project_441101_2223;

Console.WriteLine("Hello, World!");

ProjectManager projectManager = new ProjectManager();

Project greenland = new Project(10000, "L");
Project house = new Project(12000, "R");
Project flat = new Project(100000, "L");


projectManager.AddProject(greenland);

projectManager.AddProject(house);

projectManager.AddProject(flat);

ProjectManagerMenu projectManagerMenu = new ProjectManagerMenu(projectManager);


projectManagerMenu.Select();





