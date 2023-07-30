using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace Mantis_tests
{
    [TestFixture]
    public class RemoveProjectTest : AuthTestBase
    {
        [Test]
        public void TestRemoveProject()
        {
            int number = 8; //порядковый номер проекта

            List<ProjectData> oldProjectsList = app.Project.GetProjectsList();

            if (oldProjectsList.Count < number)
            {
                do
                {
                    app.Project.CreateSomeProject();
                    oldProjectsList = app.Project.GetProjectsList();
                }
                while (oldProjectsList.Count < number);
            }
            ProjectData toBeRemoved = oldProjectsList[number - 1];

            app.Navigator.ToProjectPage(number);
            app.Project.ClickToRemoveProject();
            app.Project.SubmitRemoveProject();
            
            List<ProjectData> newProjectsList = app.Project.GetProjectsList();

            //Проверка количества проектов
            Assert.AreEqual(oldProjectsList.Count - 1, newProjectsList.Count);

            oldProjectsList.Sort((left, right) => left.Name.CompareTo(right.Name));
            newProjectsList.Sort((left, right) => left.Name.CompareTo(right.Name));
            oldProjectsList.RemoveAt(number - 1);

            //Проверка списков проектов
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }
    }
}
