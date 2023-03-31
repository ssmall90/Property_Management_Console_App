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
     public class ProjectManagerMenu: IMenu
    {
        private ProjectManager _projectManager;
        public ProjectManager _ProjectManager { get { return _projectManager; } set { } } 


        private List<IMenuItem> _menuitems;

       
        public ProjectManagerMenu(ProjectManager manager) 
        { 
            _projectManager = manager;
            _menuitems = new List<IMenuItem>();

        }


        public string MenuText()
        {
            return "Project Manager Menu" + ToString();
        }

        public void CreateMenu()
        {
            _menuitems.Add(new AddNewProjectMenuItem());

            if (_projectManager.Projects.Count > 0)
            {
                _menuitems.Add(new EditExisitingProjectMenuItem());
                _menuitems.Add(new RemoveExistingProjectMenuItem());
            }

            MenuText();

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _menuitems.Count - 1; i++)
            {
                sb.AppendLine($"{i+1}:" + _menuitems[i].ToString());
            }

            return sb.ToString();
        }
    }

    public class AddNewProjectMenuItem : IMenuItem
    {
        private string _title;
        public string Title { get { return _title; } set { _title = value; } }

        public void CreateMenu()
        {

        }

        public void MenuText()
        {

        }

        public AddNewProjectMenuItem ()
        {
            Title = "Add New Project";
            _title = Title;
            
        }
    }

    public class EditExisitingProjectMenuItem : IMenuItem
    {

        public void CreateMenu()
        {

        }

        public void MenuText()
        {

        }

    }

    public class RemoveExistingProjectMenuItem : IMenuItem
    {

        public void CreateMenu()
        {

        }

        public void MenuText()
        {

        }

    }

}
