using Framework.Base;
using Framework.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.UI.System.Page
{
    public class MainPage : BasePage
    {
        private IWebElement yourProfileLabel => GetElement(By.XPath("//*[text()='Your Profile']"));
        private IWebElement adminUserNameLogin => GetElement(By.XPath("(//p[text()='Amazing Admin'])[1]"));

        string tableXPAth = "//table[@id='users_list_table']";
        private IWebElement adminUserTable => GetElement(By.XPath(tableXPAth));
        private IWebElement lbadminPower => GetElement(By.XPath("//p[text()='Change the course of a waterfall']"));
        private IWebElement lblDevPower => GetElement(By.XPath("//*[text()='Debug a repellent factory storage']"));
        private IWebElement devUserNameLogin => GetElement(By.XPath("(//p[text()='Zuper Dooper Dev'])[1]"));
        private IWebElement btnLogout => GetElement(By.XPath("//a[text()='log out']"));

        private IWebElement lblTesterPower => GetElement(By.XPath("//*[text()='Voltage AND Current']"));
        private IWebElement testerUserNameLogin => GetElement(By.XPath("(//p[text()='Al Skept-Cal Tester'])[1]"));

        public MainPage(IWebDriver driver) : base(driver)
        {

        }

        private IDictionary<string, string> GetAdminTableValues()
        {
            
            var tds = adminUserTable.FindElements(By.TagName("td"));
            IDictionary<string, string> userList = new Dictionary<string, string>();
            for(int count = 0; count< tds.Count; count++)
            {
                userList.Add(tds[count].Text, tds[count + 1 ].Text);
                count++;
            }

            return userList;
        }

        private bool UserListValidation(IDictionary<string, string> userList)
        {
            try
            {
                IDictionary<string, string> userListhardedCode = new Dictionary<string, string>();
                userListhardedCode.Add("Amazing Admin", "a.admin@wearewaes.com");
                userListhardedCode.Add("Al Skept-Cal Tester", "as.tester@wearewaes.com");
                userListhardedCode.Add("Zuper Dooper Dev", "zd.dev@wearewaes.com");
                bool comparation = true;
                

                if (userList.Count == userListhardedCode.Count)
                {
                    foreach (var pair in userListhardedCode)
                    {
                        string value;
                        if (userList.TryGetValue(pair.Key, out value))
                        {
                            if (value != pair.Value)
                            {
                                comparation = false;
                                break;
                            }
                        }
                        else
                        {
                            // Require key be present.
                            comparation = false;
                            break;
                        }
                    }
                }
                else
                {
                    Trace.WriteLine("Error: Table quantity values aren't equal");
                    comparation = false;
                }


                return comparation;
            }
            catch
            {
                return false;
            }
        }

        CommonMethods cpm = new CommonMethods();
        IWebDriver driver;
        public bool isElementPresent(By locatorKey)
        {
            try
            {
                driver.FindElement(locatorKey);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool validateTableIsNotDisplayed(string cssLocator)
        {
            try
            {
                return driver.FindElement(By.XPath(tableXPAth)).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void AdminAccessValidation()
        {
            try
            {
               
                if (adminUserTable.Displayed &&
                    adminUserNameLogin.Displayed &&
                    lbadminPower.Displayed)
                {
                    Console.WriteLine("Success: Admin logged with success");

                    if(UserListValidation(GetAdminTableValues()))
                        Console.WriteLine("Success: Admin table shows the correct values");
                    else                    
                        Assert.Fail("Failed: Admin table hasn't showed the correct values");

                    btnLogout.Click();
                }
                else
                    Assert.Fail("Error: Admin failed to login");
            }
            catch
            {
                Assert.Fail("Error: Admin Login validation failed");
            }

        }

        public void DevAccessValidation()
        {
            try
            {
                if (lblDevPower.Displayed &&
                    devUserNameLogin.Displayed)
                {
                    Console.WriteLine("Success: Dev User page shows the exceted fields for this role");
                    if (validateTableIsNotDisplayed(tableXPAth) != true)
                        Console.WriteLine("Success: Dev User page doenst' display Users table list as expected");
                    else
                        Console.WriteLine("Failed: Dev User page has displayed Users table list");
                    btnLogout.Click();

                }
                else
                    Console.WriteLine("Failed: Dev User page has displayed Users table list");
            }
            catch
            {
                Console.WriteLine("Failed: Dev User page has displayed Users table list");

            }
        }

        public void TesterAccessValidation()
        {
            try
            {
                if (lblTesterPower.Displayed &&
                    testerUserNameLogin.Displayed )
                {
                    Console.WriteLine("Success: Tester User page shows the exceted fields for this role");
                    if (validateTableIsNotDisplayed(tableXPAth) != true)
                        Console.WriteLine("Success: Dev User page doenst' display Users table list as expected");
                    else
                        Console.WriteLine("Failed: Dev User page has displayed Users table list");
                    btnLogout.Click();

                }
                else
                    Console.WriteLine("Failed: Tester User page has displayed Users table list");
            }
            catch
            {
                Console.WriteLine("Failed: Tester User page has displayed Users table list");

            }
        }

    }
}
