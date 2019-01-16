using Framework.Base;
using FrontEnd.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using WaesHeroes;


namespace FrontEnd
{
    [TestClass]
    public class LoginValidation : BaseTest
    {

        IWebDriver driver;

        //public CommonMethods commonMethods
        //{
        //    get
        //    {
        //        return new CommonMethods();
        //    }
        //}

        
        //private LoginPage loginPage => new LoginPage(LoginPage);
       

        [TestMethod]
        public void AdminLogin()
        {
            LoginPage loginPage = new LoginPage(driver);

            //commonMethods.GoToURL();
            loginPage.ClickLoginLink();
            loginPage.TypeLogin("admin", "hero");
        }

        //[TestMethod]
        //public void DevLogin()
        //{
        //    commonMethods.GoToURL();
        //    loginPage.ClickLoginLink();
        //    loginPage.TypeLogin("admin", "hero");
        //}

        //[TestMethod]
        //public void TesterLogin()
        //{
        //    commonMethods.GoToURL();
        //    loginPage.ClickLoginLink();
        //    loginPage.TypeLogin("admin", "hero");
        //}
    }
}
