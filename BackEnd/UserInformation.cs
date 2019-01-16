using BackEnd.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;

namespace BackEnd
{
    [TestClass]
    public class UserInformation
    {
        List<string> userList = new List<string>();

        WorkFlow cpm = new WorkFlow();
        [Test]
        public void Test_AdminUserinformationDataBackEnd()
        {
            cpm.SendMessageAction("/waesheroes/api/v1/users/details?username=admin", userList);
            cpm.MessageUserValidation(userList, "admin");
        }

        [Test]
        public void Test_DevUserinformationDataBackEnd()
        {
            cpm.SendMessageAction("/waesheroes/api/v1/users/details?username=dev", userList);
            cpm.MessageUserValidation(userList, "dev");
        }

        [Test]
        public void Test_TesterUserinformationDataBackEnd()
        {
            cpm.SendMessageAction("/waesheroes/api/v1/users/details?username=tester", userList);
            cpm.MessageUserValidation(userList, "tester");
        }

        [Test]
        public void Test_AllUsersDataBackEnd()
        {
            cpm.SendMessageAction("/waesheroes/api/v1/users/all", userList);
            cpm.MessageAllValidation(userList);

        }

        [Test]
        public void Test_LoginDataBackEnd()
        {
            cpm.SendMessageAction("/waesheroes/api/v1/users/access", userList);
        }

        [Test]
        public void Test_SignUpDataBackEnd()
        {
            cpm.SendMessageAction("/waesheroes/api/v1/users", userList);
        }

        [Test]
        public void Test_UpdateDataBackEnd()
        {
            cpm.SendMessageAction("/waesheroes/api/v1/users", userList);
        }

        [Test]
        public void Test_DeleteDataBackEnd()
        {
            cpm.SendMessageAction("/waesheroes/api/v1/users", userList);
        }
    }
}
