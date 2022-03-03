using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model
{
    [Table("Users")]

    public partial class User
    {
        public int Id { get; set; }

        [Required]
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public int? Gender { get; set; }
        public string Phone { get; set; }
        public string Img { get; set; }
        public int? Access { get; set; }
        public string Address { get; set; }


        public int? Created_By { get; set; }
        public DateTime? Created_At { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public int? Status { get; set; }
    }
}

