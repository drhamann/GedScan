using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ged.Core.VO
{
    public class HelperVO
    {

        public UserContext userContext { get; set;}

        private HelperVO() {
            userContext = new UserContext();
            userContext.Database.CreateIfNotExists();
        }

        private static HelperVO helperVo { get; set; }

        public static HelperVO GetIntance() {
            if (helperVo == null) {
                helperVo = new HelperVO();
            }
            return helperVo;
        }
    }
}
