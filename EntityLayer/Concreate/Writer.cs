using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterMail { get; set; }
        public string WriterImage { get; set; }
        public string WriterAbout { get; set; }
        public string WriterPassword { get; set; }

        [NotMapped]
        [Compare("WriterPassword",ErrorMessage ="Şifrəniz uyğun gəlmir")]
        public string WriterConfirmPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
