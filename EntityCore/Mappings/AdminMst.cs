namespace EntityCore.Mappings
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AdminMst")]
    public partial class AdminMst : Interface.ILibrary
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

        public DateTime? Register_Date { get; set; }
    }
}
