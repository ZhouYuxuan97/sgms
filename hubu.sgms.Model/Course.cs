namespace hubu.sgms.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Teacher_course = new HashSet<Teacher_course>();
        }

        [Key]
        [StringLength(20)]
        public string course_id { get; set; }

        [StringLength(50)]
        public string course_name { get; set; }

        public decimal? course_credit { get; set; }

        [StringLength(10)]
        public string course_hour { get; set; }

        [StringLength(50)]
        public string course_type { get; set; }

        [StringLength(20)]
        public string college_id { get; set; }

        [StringLength(20)]
        public string class_id { get; set; }

        [StringLength(10)]
        public string course_theory { get; set; }

        [StringLength(10)]
        public string course_experiment { get; set; }

        [StringLength(50)]
        public string course_opentime { get; set; }

        [StringLength(20)]
        public string course_prior { get; set; }

        public int? status { get; set; }

        [StringLength(10)]
        public string course_photo { get; set; }

        [StringLength(10)]
        public string yuliu2 { get; set; }

        [StringLength(10)]
        public string yuliu3 { get; set; }

        public virtual Class Class { get; set; }

        public virtual College College { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher_course> Teacher_course { get; set; }
    }
}
