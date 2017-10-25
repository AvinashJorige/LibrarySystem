namespace OnlineDbRepo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BranchMst")]
    public partial class BranchMst
    {
        [Key]
        public int BranchID { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }
    }
}
