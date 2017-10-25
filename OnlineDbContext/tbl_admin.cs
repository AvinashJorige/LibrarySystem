namespace OnlineDbRepo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_admin
    {
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(6)]
        public string admin_Id { get; set; }

        [StringLength(50)]
        public string admin_name { get; set; }

        [StringLength(50)]
        public string admin_pass_hash { get; set; }

        [StringLength(50)]
        public string admin_role { get; set; }

        [StringLength(50)]
        public string admin_email_Id { get; set; }

        public string admin_photo { get; set; }

        public DateTime? admin_modified_date { get; set; }

        public DateTime? admin_join_date { get; set; }
    }
}
