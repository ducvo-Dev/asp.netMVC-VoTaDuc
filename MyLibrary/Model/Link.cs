using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model
{
    [Table("Links")]

    public partial class Link
    {
        public int Id { get; set; }

        [Required]
        public string Slug { get; set; }
        public string TypeLink { get; set; }
        public int Tableid { get; set; }
        public int? Status { get; set; }
    }
}