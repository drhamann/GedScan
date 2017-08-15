using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ged.Core.VO;
using System.Data.Entity;
using System.Linq;

namespace Ged.Tests
{
    [TestClass]
    public class UserContextTest
    {
        [TestMethod]
        public void TestInitializeDB()
        {
            var db = new UserContext();

            db.Database.CreateIfNotExists();

            UserVO userTeste = new UserVO()
            {
                Domain = "testes",
                Email = "george@testes.com.br",
                Logon = "george",
                Name = "George Hamilton Hamann"
            };

            db.users.Add(userTeste);

            db.SaveChanges();

            var dados = from u in db.users select u;

            foreach (var item in dados)
            {
                UserVO u = item;
            }

        }

        [TestMethod]
        public void TestUserDB()
        {
            var db = HelperVO.GetIntance();

            UserVO userTeste = new UserVO()
            {
                Domain = "testes",
                Email = "george@testes.com.br",
                Logon = "george",
                Name = "George Hamilton Hamann"
            };
            UserVO userDB = db.userContext.CreateUser(userTeste);

            Assert.IsNotNull(userDB);

        }
    }
}
