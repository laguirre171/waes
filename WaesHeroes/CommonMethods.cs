using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace WaesHeroes
{
    public class CommonMethods
    {
        IWebDriver driver = new ChromeDriver();

        public CommonMethods()
        {
            
            //driver.Url = "http://www.google.com";
        }

        public void GoToURL()
        {
            driver.Navigate().GoToUrl("https://waesworks.bitbucket.io");
            driver.Manage().Window.Maximize();

        }

        public static void waitForElementByXPath(string elementID, IWebDriver webDriver)
        {
            IWait<IWebDriver> wait;
            wait = new OpenQA.Selenium.Support.UI.WebDriverWait(webDriver, TimeSpan.FromMinutes(4));

            try
            {
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(elementID)));
            }
            catch
            {
                Trace.WriteLine("Error: Object didn't find");
            }

        }

    }
}
