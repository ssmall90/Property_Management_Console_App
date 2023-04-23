// See https://aka.ms/new-console-template for more information
using Capstone_Project_441101_2223;

ProjectManager projectManager = new ProjectManager();

Project greenland = new Project(10000, "L");
Project house = new Project(12000, "R");
Project flat = new Project(100000, "L");
Console.WriteLine(greenland.TotalSales);

greenland.RemovePurchase(1);

//greenland.AddPurchase();
//greenland.AddSales();
//greenland.AddSales();
//greenland.AdjustProfits();
//greenland.CalculateTaxRefund(greenland);
//greenland.RemovePurchase(1);
//greenland.RemoveSale(1);
//greenland.UpdateProject(200, "l");

projectManager.AddProject(greenland);

projectManager.AddProject(house);

projectManager.AddProject(flat);



ProjectManagerMenu projectManagerMenu = new ProjectManagerMenu(projectManager);


projectManagerMenu.Select();





