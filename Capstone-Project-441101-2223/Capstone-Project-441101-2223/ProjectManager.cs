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
    }
}
