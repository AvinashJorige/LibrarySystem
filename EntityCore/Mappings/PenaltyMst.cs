namespace EntityCore.Mappings
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PenaltyMst")]
    public partial class PenaltyMst
    {
        [Key]
        public int PID { get; set; }

        public int? SID { get; set; }

        [StringLength(50)]
        public string BookName { get; set; }

        public double? Price { get; set; }

        public double? Panalty { get; set; }

        [StringLength(500)]
        public string Detail { get; set; }

        public DateTime? EntryDate { get; set; }
    }
}
