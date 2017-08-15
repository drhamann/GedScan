using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ged.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ged.Core.VO;

namespace Ged.Core.Tests
{
    [TestClass()]
    public class LdapAuthenticatorTests
    {
        [TestMethod()]
        public void DoAuthenticationTest()
        {
            LdapAuthenticator ldapAuth = new LdapAuthenticator();
            bool expected = ldapAuth.DoAuthentication("testes.nddigital.local", "matheus.silva", "ndd@123");
            Assert.AreEqual(expected,true);
        }

        [TestMethod()]
        public void DoAuthenticationTestSimpleDomain()
        {
            LdapAuthenticator ldapAuth = new LdapAuthenticator();
            bool expected = ldapAuth.DoAuthentication("testes", "matheus.silva", "ndd@123");
            Assert.AreEqual(expected, true);
        }

        [TestMethod()]
        public void DoAuthenticationTesWrongPass()
        {
            LdapAuthenticator ldapAuth = new LdapAuthenticator();
            bool expected = ldapAuth.DoAuthentication("testes", "matheus.silva", "ndd");
            Assert.AreEqual(expected, false);
        }

        [TestMethod()]
        public void DoAuthenticationTestWrongDomain()
        {
            LdapAuthenticator ldapAuth = new LdapAuthenticator();
            bool expected = ldapAuth.DoAuthentication("nddigital", "matheus.silva", "ndd@123");
            Assert.AreEqual(expected, false);
        }


        [TestMethod()]
        public void DoAuthenticationWithDbTest()
        {
            LdapAuthenticator ldapAuth = new LdapAuthenticator();
            UserVO expected = ldapAuth.CreateSession("testes.nddigital.local", "matheus.silva", "ndd@123");
            Assert.AreEqual(expected.Logon, "matheus.silva");
        }
    }
}