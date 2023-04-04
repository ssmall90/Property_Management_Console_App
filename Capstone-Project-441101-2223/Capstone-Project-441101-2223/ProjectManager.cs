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

        public void GetFile(string file)
        {
            
            FileInfo fi = new FileInfo(file);
            FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            StreamReader streamReader = new StreamReader(fs);

            while (!streamReader.EndOfStream)
            {
                for (int i = 0; !streamReader.EndOfStream; i++)
                {
                    bool AlreadyExsisted = false;
                    string[] lineData = streamReader.ReadLine().Split(',');
                    string id = lineData[0];
                    string type = lineData[1];
                    string value = lineData[2];
                    float value1 = float.Parse(lineData[2]);
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
                            AlreadyExsisted = true;

                            break;

                        }

                    }
                    if (AlreadyExsisted == false)
                    {
                        AddProject(new Project(value1, type, id1));
                    }


                }
            }
            streamReader.Close();

        }
    }
}
