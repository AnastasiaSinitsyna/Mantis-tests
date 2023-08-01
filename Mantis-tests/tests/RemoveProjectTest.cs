using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Security.Principal;

namespace Mantis_tests
{
    [TestFixture]
    public class RemoveProjectTest : AuthTestBase
    {
        [Test]
        public void TestRemoveProject()
        {
            int number = 5; //порядковый номер проекта

            List<ProjectData> projectsOld = app.API.CreateProjectList(new AccountData("administrator", "root"));
            
            if (projectsOld.Count < number)
            {
                do
                {
                    app.API.CreateSomeProject(new AccountData("administrator", "root"), "Удачная сделка");
                    projectsOld = app.API.CreateProjectList(new AccountData("administrator", "root"));
                }
                while (projectsOld.Count < number);
            }
            ProjectData toBeRemoved = projectsOld[number - 1];

            app.Navigator.ToProjectsPage()
            .ToProjectPage(number);
            app.Project.ClickToRemoveProject();
            app.Project.SubmitRemoveProject();
            
            List<ProjectData> projectsNew = app.API.CreateProjectList(new AccountData("administrator", "root"));

            //Проверка количества проектов
            Assert.AreEqual(projectsOld.Count - 1, projectsNew.Count);

            projectsOld.Sort((left, right) => left.Name.CompareTo(right.Name));
            projectsNew.Sort((left, right) => left.Name.CompareTo(right.Name));
            projectsOld.RemoveAt(number - 1);

            //Проверка списков проектов
            Assert.AreEqual(projectsOld, projectsNew);

        }
    }
}
