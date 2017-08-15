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

            this.users.Add(user);
            this.SaveChanges();
            return SelectUserByLogonAndDomain(user.Domain, user.Logon);
        }

        public UserVO SelectUserByLogonAndDomain(String Domain, String Logon) {
            var usersFromDb = from u in users where u.Domain.Equals(Domain) && u.Logon.Equals(Logon) select u;

            return usersFromDb.ToList()[0];
        }
    }
}
