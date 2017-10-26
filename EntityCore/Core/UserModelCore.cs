using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCore.Core
{
    public class UserModelCore
    {
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

        [Key]
        public int SID { get; set; }

        [StringLength(50)]
        public string StudentName { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Pincode { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Image { get; set; }
    }
}
