using System;
using System.Net;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Security.Permissions;
using Ged.Core.VO;

namespace Ged.Core
{
    public class LdapAuthenticator
    {
        public bool DoAuthentication(string Domain, string User, string Password)
        {
            try
            {
                // Create the new LDAP connection
                LdapDirectoryIdentifier ldi = new LdapDirectoryIdentifier(Domain, 389);
                LdapConnection ldapConnection = new LdapConnection(ldi);
                Console.WriteLine("LdapConnection is created successfully.");
                ldapConnection.AuthType = AuthType.Basic;
                ldapConnection.SessionOptions.ProtocolVersion = 3;
         
                NetworkCredential nc = new NetworkCredential(User+"@"+Domain, Password); //password
                ldapConnection.Bind(nc);
                Console.WriteLine("LdapConnection authentication success");
                ldapConnection.Dispose();
                return true;
            }
            catch (LdapException e)
            {
                Console.WriteLine("\r\nUnable to login:\r\n\t" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" + e.GetType() + ":" + e.Message);
            }

            return false;
        }

        public UserVO CreateSession(string Domain, string User, string Password) {

            if (DoAuthentication(Domain,User,Password)) {
                UserVO userVo = new UserVO()
                {
                    Domain = Domain,
                    Logon = User
                };

                return HelperVO.GetIntance().userContext.CreateUser(userVo);
            }

            return null;
        }

    }
}
