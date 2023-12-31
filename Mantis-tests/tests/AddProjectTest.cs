﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_tests
{
    [TestFixture]
    public class AddProjectTest : AuthTestBase
    {
        [Test]
       public void TestAddProject()
        {
            ProjectData newProject = new ProjectData();
            newProject.Name = "Новый проект";

            List<ProjectData> oldProjectsList = app.API.CreateProjectList(new AccountData("administrator", "root"));

            //Проверка дублирующихся имен
            if (oldProjectsList.Any(p => p.Name == newProject.Name))
            {
                newProject.Name = GenerateRandomString(10);
            }

            app.Navigator.ToProjectsPage()
            .ToAddProjectPage();
            app.Project.FillProjectInformation(newProject);
            app.Project.Submit();

            List<ProjectData> newProjectsList = app.API.CreateProjectList(new AccountData("administrator", "root"));

            //Проверка количества проектов
            Assert.AreEqual(oldProjectsList.Count +1, newProjectsList.Count);

            oldProjectsList.Add(newProject);
            oldProjectsList.Sort((left, right) => left.Name.CompareTo(right.Name));
            newProjectsList.Sort((left, right) => left.Name.CompareTo(right.Name));

            //Проверка списков проектов
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }
    }
}
