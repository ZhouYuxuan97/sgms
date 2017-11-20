namespace hubu.sgms.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Course_choosing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course_choosing()
        {
            Course_choosing1 = new HashSet<Course_choosing>();
        }

        [Key]
        [StringLength(20)]
        public string course_choosing_id { get; set; }

        [StringLength(20)]
        public string student_id { get; set; }

        [StringLength(50)]
        public string student_name { get; set; }

        [StringLength(20)]
        public string teacher_course_id { get; set; }

        [StringLength(20)]
        public string cou_course_choosing_id { get; set; }

        [StringLength(20)]
        public string teacher_id { get; set; }

        [StringLength(50)]
        public string teacher_name { get; set; }

        [StringLength(50)]
        public string course_id { get; set; }

        [StringLength(50)]
        public string course_name { get; set; }

        [StringLength(50)]
        public string classroom_id { get; set; }

        public decimal? usual_grade { get; set; }

        public decimal? test_grade { get; set; }

        public decimal? total_grade { get; set; }

        public decimal? course_credit { get; set; }

        [Column("class")]
        [StringLength(255)]
        public string _class { get; set; }

        public int? status { get; set; }

        [StringLength(10)]
        public string yuliu1 { get; set; }

        [StringLength(10)]
        public string yuliu2 { get; set; }

        [StringLength(10)]
        public string yuliu3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_choosing> Course_choosing1 { get; set; }

        public virtual Course_choosing Course_choosing2 { get; set; }

        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Teacher_course Teacher_course { get; set; }
    }
}
