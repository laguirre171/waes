using BackEnd.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Message
{
    public class WorkFlow
    {
        CommonBackEndMethods cp;
        public void SendMessageAction(string path, List<string> userList)
        {            
            cp.GetWebServiceValidation(path, "admin", "wizard", out userList);
        }

        public void MessageUserValidation(List<string> userList, string user)
        {
            if (user.Equals("admin"))
                if (ValidateUserData(userList, "0", "admin", "a.admin@wearewaes.com", "Change the course of a waterfall.", "true"))
                    Console.WriteLine("Success: User information is displayed as expected");
                else
                    Assert.Fail("Failed: User information ISN'T displayed as expected");

            if (user.Equals("dev"))
                if (ValidateUserData(userList, "1", "dev", "zd.dev@wearewaes.com", "Debug a repellent factory storage.", "false"))
                    Console.WriteLine("Success: User information is displayed as expected");
                else
                    Assert.Fail("Failed: User information ISN'T displayed as expected");

            if (user.Equals("tester"))
                if (ValidateUserData(userList, "2", "tester", "as.tester@wearewaes.com", "Voltage AND Current", "false"))
                    Console.WriteLine("Success: User information is displayed as expected");
                else
                    Assert.Fail("Failed: User information ISN'T displayed as expected");

        }

        public void MessageAllValidation(List<string> userList)
        {
            
            if (ValidateUserData(userList, "0", "admin", "a.admin@wearewaes.com", "Change the course of a waterfall.", "true"))
                Console.WriteLine("Success: User information is displayed as expected");
            else
                Assert.Fail("Failed: User information ISN'T displayed as expected");

            if (ValidateUserData(userList, "1", "dev", "zd.dev@wearewaes.com", "Debug a repellent factory storage.", "false"))
                Console.WriteLine("Success: User information is displayed as expected");
            else
                Assert.Fail("Failed: User information ISN'T displayed as expected");

            if (ValidateUserData(userList, "2", "tester", "as.tester@wearewaes.com", "Voltage AND Current", "false"))
                Console.WriteLine("Success: User information is displayed as expected");
            else
                Assert.Fail("Failed: User information ISN'T displayed as expected");

        }
               
        private static bool ValidateUserData(List<string> userList, string id, string name, string email, string power, string adminFlag)
        {
            if (userList[0].Contains(id) &&
               userList[0].Contains(name) &&
               userList[0].Contains(email) &&
               userList[0].Contains(power) &&
               userList[0].Contains(adminFlag))
                return true;
            else
                return false;
        }
    }
}
