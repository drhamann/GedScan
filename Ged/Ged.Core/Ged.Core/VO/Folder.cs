using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ged.Core.VO
{
    [Table("Folder")]
    public class Folder
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<GedFiles> Files { get; set; }
    }
}