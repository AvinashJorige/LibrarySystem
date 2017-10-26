namespace EntityCore.Mappings
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RentMst")]
    public partial class RentMst : Interface.ILibrary
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
