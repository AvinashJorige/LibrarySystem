namespace OnlineDbRepo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminMst")]
    public partial class AdminMst
    {
        [Key]
        public int AID { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public DateTime? EntryDate { get; set; }

        [StringLength(50)]
        public string Email_Id { get; set; }

        public string Img { get; set; }

        [StringLength(1000)]
        public string HashKey { get; set; }
        public DateTime? Register_Date { get; set; }
    }
}
