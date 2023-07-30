using NUnit.Framework;
using OpenQA.Selenium.DevTools.V113.FedCm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using(Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData("testuser", "123456")
            {
                Email = "testuser@localhost.localdomain"
            };
            
            app.Registration.Register(account);
        }
        [TearDown]
        public void restoreConfig() 
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
