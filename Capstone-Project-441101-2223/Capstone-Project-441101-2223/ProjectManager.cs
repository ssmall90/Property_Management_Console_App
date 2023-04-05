using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project_441101_2223
{
    public class ProjectManager
    {
        public List<Project> _projects;

        public ProjectManager()
        {
            _projects = new List<Project>();

        }

        public void AddProject(Project project)
        {
            
            _projects.Add(project);
        }

        public void RemoveProject()
        {
            Console.WriteLine("Which Project Would You Like To Remove\r\n");

            for (int i = 0; i < _projects.Count; i++)
            {
                Console.WriteLine($"{i + 1} {_projects[i]}");
            }

            int selectedProject = MenuExtras.GetItemInRange(0, _projects.Count);

            _projects.RemoveAt(selectedProject - 1);
        }

         public void UploadFile()
        {
            bool isValid = false;
            do
            {
                Console.WriteLine("Please Enter Enter The Name Of The .txt or .tml File You Want To Upload To The System");
                string userInput = Console.ReadLine();
                Console.WriteLine("");
                try
                {
                    string testData = userInput.Split('.')[1];

                }
                catch
                {
                    Console.WriteLine("File Not Valid. \r\n\r\nPlease Ensure You Enter The Full File Name E.g. 'file.txt', 'file.tml'");
                    Console.WriteLine();
                    continue;
                }
                switch (userInput.Split('.')[1])
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
        public void GetTMLFile(string file)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("File Could Not Be Found");
                Console.WriteLine();
                UploadFile();
            }
            FileInfo fi = new FileInfo(file);
            FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(fs);

            while (!streamReader.EndOfStream)
            {
                bool hasError = false;

                for (int i = 0; !streamReader.EndOfStream; i++)
                {
                    bool alreadyExsisted = false;


                    string[] lineData = streamReader.ReadLine().Split('(',')',' ','=',';');
                    string id = string.Empty;
                    string type = string.Empty;
                    string value = string.Empty;
                    float value1;

                    try
                    {
                        id = lineData[1];
                        type = lineData[0].ToUpper();
                        value = lineData[5];
                    }
                    catch
                    {
                        Console.WriteLine($"Error Processing Input File \"{file}\"\n" +
                            $"There Was An Error Processing A Value Of The Input File At Line \"{i + 1}\".\n" +
                            $"Please Ensure Each Entry Of The File Is Formatted Correctly.\n" +
                            $"E.g, (Land(109) = 4199;)");
                        Environment.Exit(1);
                    }

                    try
                    {
                        value1 = float.Parse(lineData[5]);

                    }
                    catch
                    {
                        Console.WriteLine($"Error Processing Input File \"{file}\"\n" +
                            $"There Was An Error Processing The Value Of The Purchase / Sale Of The Input File At Line \"{i + 1}\".\n" +
                            $"Please Ensure Each Entry Of The File Is Formatted Correctly.\n" +
                            $"E.g, (Land(109) = 4199;).");
                        hasError = true;

                        continue;

                    }

                    if (hasError == true)
                    {
                        Environment.Exit(1);
                    }
                    int id1 = int.Parse(lineData[1]);

                    for (int j = 0; j < _projects.Count; j++)
                    {
                        if (id != _projects[j].ID.ToString())
                        {
                            continue;

                        }
                        else if (id == _projects[j].ID.ToString())
                        {

                            _projects[j].UpdateProject(value1, type);
                            alreadyExsisted = true;

                            break;

                        }

                    }
                    if (alreadyExsisted == false)
                    {
                        if (type.ToUpper() == "RENOVATION" || type.ToUpper() == "LAND")
                        {
                            string type1 = type.Substring(0,1).ToUpper();
                            AddProject(new Project(value1, type1, id1));
                        }
                        else
                        {
                            Console.WriteLine($"Error Processing Input File \"{file}\"\n" + "A New Entry Into The System Must Be Defined With A Land Or Renovation Purchase.\n" +
                                $"The Project At Entry \"{i + 1}\" Of The Input File Does Not Adhere To These Rules.\n" +
                                $"Please Update The Project To Include \'{"Land"}\' Or \'{"Renovation"}\' As The Initial Purchase Option");
                            Environment.Exit(1);
                        }

                    }


                }
            }
            streamReader.Close();

        }

        public void GetCSVFile(string file)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("File Could Not Be Found");
                Console.WriteLine();
                UploadFile();
            }
            FileInfo fi = new FileInfo(file);
            FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(fs);

            while (!streamReader.EndOfStream)
            {
                bool hasError = false;

                for (int i = 0; !streamReader.EndOfStream; i++)
                {
                    bool alreadyExsisted = false;


                    string[] lineData = streamReader.ReadLine().Split(',');
                    string id = string.Empty;
                    string type = string.Empty;
                    string value = string.Empty;
                    float value1;
                    try
                    {
                        id = lineData[0];
                        type = lineData[1].ToUpper();
                        value = lineData[2];
                    }
                    catch
                    {
                        Console.WriteLine($"Error Processing Input File \"{file}\"\n" +
                            $"There Was An Error Processing A Value Of The Input File At Line \"{ i + 1}\".\n" +
                            $"Please Ensure Each Entry Of The File Is Formatted Correctly.\n" +
                            $"E.g, (111,L,1000) With Each Value Seperated By A Comma.");
                        Environment.Exit(1);
                    }

                    try
                    {
                        value1 = float.Parse(lineData[2]);
                      
                    }
                    catch
                    {
                        Console.WriteLine($"Error Processing Input File \"{file}\"\n" +
                            $"There Was An Error Processing The Value Of The Purchase / Sale Of The Input File At Line \"{i + 1}\".\n" +
                            $"Please Ensure Each Entry Of The File Is Formatted Correctly.\n" +
                            $"E.g, (111,L,1000).");
                        hasError = true;

                        continue;

                    }

                    if (hasError == true)
                    {
                        Environment.Exit(1);
                    }
                    int id1 = int.Parse(lineData[0]);

                    for (int j = 0; j < _projects.Count; j++)
                    {
                        if (id != _projects[j].ID.ToString())
                        {
                            continue;

                        }
                        else if (id == _projects[j].ID.ToString())
                        {

                            _projects[j].UpdateProject(value1, type);
                            alreadyExsisted = true;

                            break;

                        }

                    }
                    if (alreadyExsisted == false)
                    {
                        if (type == "R" || type == "L")
                        {
                            
                            AddProject(new Project(value1, type, id1));
                        }
                        else
                        {
                            Console.WriteLine($"Error Processing Input File \"{file}\"\n" + "A New Entry Into The System Must Be Defined With A Land Or Renovation Purchase.\n" +
                                $"The Project At Entry \"{i + 1}\" Of The Input File Does Not Adhere To These Rules.\n" +
                                $"Please Update The Project To Include \'{"L"}\' Or \'{"R"}\' As The Initial Purchase Option");
                            Environment.Exit(1);
                        }

                    }


                }
            }
            streamReader.Close();

        }
    }
}
