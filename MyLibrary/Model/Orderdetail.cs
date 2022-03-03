using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model
{
    [Table("Orderdetails")]

    public partial class Orderdetail
    {
        public int Id { get; set; }

        [Required]
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public float Amount { get; set; }

    }
}
