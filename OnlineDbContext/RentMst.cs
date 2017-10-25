namespace OnlineDbRepo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RentMst")]
    public partial class RentMst
    {
        [Key]
        public int RID { get; set; }

        [StringLength(50)]
        public string BookName { get; set; }

        public int? SID { get; set; }

        public int? Days { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? Status { get; set; }
    }
}
