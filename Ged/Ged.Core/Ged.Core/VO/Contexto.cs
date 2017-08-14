using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ged.Core.VO
{
    public class Contexto : DbContext
    {
        public DbSet<UserVO> users { get; set; }

    }
}
