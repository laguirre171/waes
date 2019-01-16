using System;
using System.Configuration;
using Framework.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Framework.Base
{
    public class BaseTest
    {
        protected IWebDriver _driver;
        //CommonMethods cpm;
        //public BaseTest()
        //{
        //    //_driver = driver;
        //    //this.cpm = new CommonMethods(_driver);
        //}

        [SetUp]
        public void SetupTest()
        {
            _driver = new DriverFactory().Initialize(ConfigurationManager.AppSettings["DefaultBrowser"]);
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseURL"]);
            _driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void TearDownTest()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
