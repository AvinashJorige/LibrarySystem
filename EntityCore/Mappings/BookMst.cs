using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCore.Mappings
{
    [Table("BookMst")]
    public partial class BookMst
    {
        [Key]
        public int BookID { get; set; }

        [StringLength(50)]
        public string BookName { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(50)]
        public string Detail { get; set; }

        public double? Price { get; set; }

        [StringLength(50)]
        public string Publication { get; set; }

        [StringLength(50)]
        public string Branch { get; set; }

        public int? Quantities { get; set; }

        public int? AvailableQnt { get; set; }

        public int? RentQnt { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        [StringLength(1000)]
        public string BookPDF { get; set; }

        public DateTime? EntryDate { get; set; }
    }
}
