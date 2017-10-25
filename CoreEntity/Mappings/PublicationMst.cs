namespace CoreEntity.Mappings
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PublicationMst")]
    public partial class PublicationMst : AuditableEntity<long>
    {
        [Key]
        public int PID { get; set; }

        [StringLength(100)]
        public string Publication { get; set; }

        public DateTime? EntryDate { get; set; }
    }
}
