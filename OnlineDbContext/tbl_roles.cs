namespace OnlineDbRepo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_roles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Role_name { get; set; }

        [StringLength(50)]
        public string Details { get; set; }

        public DateTime? Modified_Date { get; set; }
    }
}
