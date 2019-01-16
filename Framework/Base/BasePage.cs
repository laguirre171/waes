using Framework.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.IO;

namespace Framework.Base
                        
{
    public class BasePage : BaseElement
    {
        private IWebDriver _driver;
        public BasePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;            
        }

        public TestContext TestContext { get; set; }

       
       

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public void DismissAlert()
        {
            _driver.SwitchTo().Alert().Dismiss();
        }
    }
}
