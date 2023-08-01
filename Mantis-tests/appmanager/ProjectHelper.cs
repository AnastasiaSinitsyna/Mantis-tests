using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_tests
{
    public class ProjectHelper : HelperBase
    {

        public ProjectHelper(ApplicationManager manager)
        : base(manager)
        {
        }
        public ProjectHelper FillProjectInformation(ProjectData newProject)
        {
            Type(By.Id("project-name"), newProject.Name);
            return this;

        }

        public ProjectHelper Submit()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            driver.FindElement(By.LinkText("Продолжить")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(2))
                .Until(d => d.FindElements(By.CssSelector("div.table-responsive")).Count > 0);

            return this;
        }

        public ProjectHelper ClickToRemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            return this;
        }

        public ProjectHelper SubmitRemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2))
                 .Until(d => d.FindElements(By.CssSelector("div.table-responsive")).Count > 0);
            return this;
        }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> projectList = null;
                projectList = new List<ProjectData>();
                manager.Navigator.ToProjectsPage();
                ICollection<IWebElement> rows = driver.FindElements
                    (By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr"));
                foreach (IWebElement row in rows)
                {
                    string name = row.FindElement(By.XPath("./td[1]")).Text;
                    string description = row.FindElement(By.XPath("./td[5]")).Text;
                    projectList.Add(new ProjectData(name, description));
                }
            return projectList;
        }

        public void CreateSomeProject()
        {
            ProjectData project = new ProjectData();
            project.Name = TestBase.GenerateRandomString(5);
            project.Description = TestBase.GenerateRandomString(10);

            manager.Navigator.ToProjectsPage()
                            .ToAddProjectPage();
            FillProjectInformation(project);
            Submit();
        }


    }
}
