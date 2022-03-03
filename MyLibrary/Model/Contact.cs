using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model
{
    [Table("Contacts")]

    public partial class Contact
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public String Title { get; set; }



        public string Detail { get; set; }
        public string ReplayDetail { get; set; }

        public DateTime? Created_At { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public int? Status { get; set; }
    }
}