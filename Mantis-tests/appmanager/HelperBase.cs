using OpenQA.Selenium;
using System;
using System.IO;

namespace Mantis_tests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
        public void Type(By locator, string text)
        {
            if (text == null)
                throw new ArgumentNullException();

            driver.FindElement(locator).Click();
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);

        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsElementNoPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
    }
}