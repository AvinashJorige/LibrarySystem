namespace OnlineDbRepo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PublicationMst")]
    public partial class PublicationMst
    {
        [Key]
        public int PID { get; set; }

        [StringLength(100)]
        public string Publication { get; set; }

        public DateTime? EntryDate { get; set; }
    }
}
