namespace CoreEntity.Mappings
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BranchMst")]
    public partial class BranchMst : AuditableEntity<long>
    {
        [Key]
        public int BranchID { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }
    }
}
