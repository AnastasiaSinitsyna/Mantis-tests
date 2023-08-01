using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Mantis_tests.Mantis;
using System.Collections.Immutable;
using System.Xml.Linq;
using OpenQA.Selenium;

namespace Mantis_tests
{
    public class APIHelper : HelperBase
    {

        public APIHelper(ApplicationManager manager)
        : base(manager)
        {
        }
        public List<ProjectData> CreateProjectList(AccountData account)
        {
            MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);

            List<ProjectData> projectCache = new List<ProjectData>();
            ProjectData n = new ProjectData();
            for (int i = 0; i < projects.Length; i++)
            {
                string name = projects[i].name;
                projectCache.Add(new ProjectData()
                {
                    Name = name, 
                }) ;
            }
            return projectCache;
        }

        public void CreateSomeProject(AccountData account, string name)
        {
            MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = name;
            client.mc_project_add(account.Name, account.Password, project);
        }
    }
}
