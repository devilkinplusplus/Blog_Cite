using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string NewsMail { get; set; }
        public bool NewsStatus { get; set; }
        
    }
}
