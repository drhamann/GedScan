using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ged.Core.VO
{
    public class UserContext : DbContext
    {
        public DbSet<UserVO> users { get; set; }

        //public UserContext() :base()

        public UserVO CreateUser(UserVO user) {
            UserVO UserFromDB = this.SelectUserByLogonAndDomain(user.Domain, user.Logon);
            if (UserFromDB == null)
           
            {
                this.users.Add(user);
                this.SaveChanges();
                UserFromDB = SelectUserByLogonAndDomain(user.Domain, user.Logon);
            }
            return UserFromDB;
        }

        public UserVO SelectUserByLogonAndDomain(String Domain, String Logon) {
            var usersFromDb = from u in users where u.Domain.Equals(Domain) && u.Logon.Equals(Logon) select u;
            if (usersFromDb.ToList().Count == 0)
                return null;
                return usersFromDb.ToList()[0];
        }
    }
}
