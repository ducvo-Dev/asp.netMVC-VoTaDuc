using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model
{
    [Table("Products")]

    public partial class Product
    {
        public int Id { get; set; }

        [Required]
        public int Catid { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Img { get; set; }
        public string Detail { get; set; }
        public string Number { get; set; }
        public string Price { get; set; }
        public string Pricesale { get; set; }



        public string Metakey { get; set; }
        public string MetaDesc { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_At { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public int? Status { get; set; }
    }
}
    