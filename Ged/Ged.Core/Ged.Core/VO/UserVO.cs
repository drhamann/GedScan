using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ged.Core.VO
{
    [Table("User")]
    public class UserVO
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Logon { get; set; }
        public string Domain { get; set; }
        public List<Folder> GetFolder { get; set; }
    }
}
