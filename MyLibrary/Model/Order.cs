using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model
{
    [Table("Orders")]

    public partial class Order
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }
        public string Userid { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Exportdate { get; set; }



        public string Deliveryaddress { get; set; }
        public string Deliveryname { get; set; }
        public string Deliveryphone { get; set; }
        public string Deliveryemail { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public int? Status { get; set; }

    }
}
