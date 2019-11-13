using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem
{
   public class SideBars : BaseEntity
    {
        [StringLength(30),Column(TypeName = "varchar")]
        public string Name { get; set; }
        [StringLength(20), Column(TypeName = "varchar")]
        public string Controller { get; set; }
        [StringLength(20), Column(TypeName = "varchar")]
        public string Action { get; set; }
    }
}
