using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WaesHeroes;
using Framework.Base;

namespace FrontEnd.PageObjects
{
   
    public class LoginPage : BasePage
    {

        IWebDriver driver;


        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        #region Objects
        private IWebElement TextUserName
        {
            get
            {
                CommonMethods.waitForElementByXPath("//*[@id='username_input']", driver);
                return driver.FindElement(By.XPath("//*[@id='username_input']"));

            }
        }

        private IWebElement TextPassword
        {
            get
            {
                CommonMethods.waitForElementByXPath("//*[@id='password_input']", driver);
                return driver.FindElement(By.XPath("//*[@id='password_input']"));

            }
        }


        private IWebElement LblLogin
        {
            get
            {
                CommonMethods.waitForElementByXPath("//*[@id='login_link']", driver);
                return driver.FindElement(By.XPath("//*[@id='login_link']"));

            }
        }

        #endregion

        public void ClickLoginLink()
        {
            LblLogin.Click();
        }

        public void TypeLogin(string username, string password)
        {
            TextUserName.SendKeys(username);
            TextPassword.SendKeys(password);
        }
    }
}
