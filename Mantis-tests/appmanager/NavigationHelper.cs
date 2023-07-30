using OpenQA.Selenium;
using System;

namespace Mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
        : base(manager)
        {
            this.baseURL = baseURL;
        }

        public NavigationHelper ToAddProjectPage()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }

        public NavigationHelper ToProjectsPage()
        {
            if (driver.Url == baseURL + "manage_proj_page.php"
    && IsElementPresent(By.CssSelector("div.table-responsive")))
            {
                return this;
            }
            driver.FindElement(By.LinkText("Управление")).Click();
            driver.FindElement(By.LinkText("Управление проектами")).Click();
            return this;
        }

        internal NavigationHelper ToProjectPage(int i)
        {
          driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']" +
              "/tbody/tr[" + i + "]/td[1]/a")).Click();
            return this;
        }
    }
}