using Framework.Base;
using Framework.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Test.Selenium.Sistema.Page;
using Test.UI.System.Page;

namespace Test.Selenium.Sistema.Test
{
    
    [TestClass]
    public class LoginValidation : BaseTest
    {

        private Login loginPage
        {
            get
            {
                return new Login(_driver);
            }
        }

        private MainPage mainPage
        {
            get
            {
                return new MainPage(_driver);
            }
        }

        private NUnit.Framework.TestContext testContextInstance;

        CommonMethods cpm;

        //[TestInitialize]
        //public void OpenLog()
        //{
        //    cpm.OpenLog();
        //}

        //[TestCleanup]
        //public void CloseLog()
        //{
        //    cpm.CloseLog();
        //}

        [Test]
        public void Test_LoginAsAdmin()
        {
            loginPage.LoginOnSystemAction("admin", "hero");
            mainPage.AdminAccessValidation();
            loginPage.ReturnLoginPageValidation();
        }

        [Test]
        public void Test_LoginAsDev()
        {
            loginPage.LoginOnSystemAction("dev", "wizard");            
            mainPage.DevAccessValidation();
            loginPage.ReturnLoginPageValidation();
        }

        [Test]
        public void Test_LoginAsTester()
        {
            loginPage.LoginOnSystemAction("tester", "maniac");
            mainPage.TesterAccessValidation();
            loginPage.ReturnLoginPageValidation();
        }

        [Test]
        public void Test_LoginAsWrongUserPassword()
        {
            
            loginPage.LoginOnSystemAction("error", "error");
            loginPage.ReturnLoginPageValidation();
        }

        [Test]
        public void Test_LoginAsWrongPassword()
        {
            loginPage.LoginOnSystemAction("admin", "error");
            loginPage.ReturnLoginPageValidation();
        }
    }
}
