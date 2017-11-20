namespace hubu.sgms.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teacher_course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher_course()
        {
            Course_choosing = new HashSet<Course_choosing>();
        }

        [Key]
        [StringLength(20)]
        public string teacher_course_id { get; set; }

        [StringLength(20)]
        public string course_id { get; set; }

        [StringLength(50)]
        public string course_name { get; set; }

        [StringLength(20)]
        public string teacher_id { get; set; }

        [StringLength(50)]
        public string teacher_name { get; set; }

        [Column("class")]
        [StringLength(255)]
        public string _class { get; set; }

        [StringLength(20)]
        public string class_id { get; set; }

        [StringLength(50)]
        public string grade { get; set; }

        [StringLength(255)]
        public string department { get; set; }

        [StringLength(20)]
        public string college_id { get; set; }

        [StringLength(255)]
        public string major { get; set; }

        [StringLength(20)]
        public string major_id { get; set; }

        public decimal? course_credit { get; set; }

        [StringLength(50)]
        public string classroom_id { get; set; }

        public int? status { get; set; }

        [StringLength(10)]
        public string yuliu1 { get; set; }

        [StringLength(10)]
        public string yuliu2 { get; set; }

        public virtual Class Class1 { get; set; }

        public virtual College College { get; set; }

        public virtual Course Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_choosing> Course_choosing { get; set; }

        public virtual Major Major1 { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
