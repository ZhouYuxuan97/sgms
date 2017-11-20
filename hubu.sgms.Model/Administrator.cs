namespace hubu.sgms.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrator")]
    public partial class Administrator
    {
        [Key]
        [StringLength(20)]
        public string administrator_id { get; set; }

        [StringLength(50)]
        public string administrator_name { get; set; }

        [StringLength(10)]
        public string administratort_sex { get; set; }

        [StringLength(20)]
        public string administrator_id_card { get; set; }

        [StringLength(255)]
        public string administrator_department { get; set; }

        [StringLength(400)]
        public string administrator_photo { get; set; }

        [StringLength(20)]
        public string administrator_contact { get; set; }

        [StringLength(400)]
        public string administrator_other { get; set; }

        public int? status { get; set; }

        [StringLength(10)]
        public string yuliu1 { get; set; }

        [StringLength(10)]
        public string yuliu2 { get; set; }
    }
}
