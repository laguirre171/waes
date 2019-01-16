using OpenQA.Selenium;
using Framework.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Framework.Helper;
using System.Text;
using System.IO;
using System;

namespace Test.Selenium.Sistema.Page
{
    public class Login : BasePage
    {

        private IWebElement lnkLogin => GetElement(By.XPath("//*[@id='login_link']"));
        private IWebElement login => GetElement(By.XPath("//*[@id='username_input']"));
        private IWebElement password => GetElement(By.XPath("//*[@id='password_input']"));
        private IWebElement btnAccesss => GetElement(By.XPath("//*[@id='login_button']"));
        private IWebElement lblLogin => GetElement(By.XPath("//*[text()='Log In']"));

        CommonMethods cpm;
        IWebDriver driver;
        public Login(IWebDriver driver) : base (driver)
        {
            this.cpm = new CommonMethods(driver);
        }

        public bool LoginLabelValidation()
        {
            try
            {
                if (lblLogin.Displayed)
                {
                    Console.WriteLine("Success: Login Header Label is displayed as expected");
                    return true;
                }
                else
                {
                    Assert.Fail("Error: Login Label isn't displayed");
                    return false;
                }
            }
            catch
            {
                Assert.Fail("Error: Login Label isn't displayed");
                return false;
            }
        }

        public void ClickLoginLabel()
        {
            lnkLogin.Click();
        }

        public void TypeUser(string value)
        {
            Type(login, value);
        }

        public void TypePassword(string value)
        {
            Type(password, value);
        }

        public void ClickLoginButton()
        {
            Click(btnAccesss);
        }

       
        public void LoginOnSystemAction(string user, string password)
        {
            ClickLoginLabel();
            //LoginLabelValidation();
            TypeUser(user);
            TypePassword(password);
            ClickLoginButton();
            
        }

               
        public void ReturnLoginPageValidation()
        {           
           
            if (LoginLabelValidation())
                Console.WriteLine("Success: Logout worked as expected");
            else
                Assert.Fail("Error: Logout isn't working as expected");

           
        }
       
       
    }
}
