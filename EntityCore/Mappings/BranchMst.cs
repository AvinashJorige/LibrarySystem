using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCore.Mappings
{
    [Table("BranchMst")]
    public partial class BranchMst : Interface.ILibrary
    {
        [Key]
        public int BranchID { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }
    }
}
