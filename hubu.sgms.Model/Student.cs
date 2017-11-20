namespace hubu.sgms.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Course_choosing = new HashSet<Course_choosing>();
        }

        [Key]
        [StringLength(20)]
        public string student_id { get; set; }

        [Required]
        [StringLength(50)]
        public string student_name { get; set; }

        [StringLength(10)]
        public string student_sex { get; set; }

        public int? student_age { get; set; }

        [StringLength(20)]
        public string student_id_card { get; set; }

        [StringLength(255)]
        public string student_department { get; set; }

        [StringLength(20)]
        public string college_id { get; set; }

        [StringLength(255)]
        public string student_major { get; set; }

        [StringLength(20)]
        public string course_id { get; set; }

        [StringLength(50)]
        public string student_grade { get; set; }

        [StringLength(20)]
        public string class_id { get; set; }

        [StringLength(50)]
        public string student_type { get; set; }

        [StringLength(255)]
        public string student_address { get; set; }

        [StringLength(100)]
        public string student_native { get; set; }

        [StringLength(255)]
        public string student_birthplace { get; set; }

        [StringLength(400)]
        public string student_photo { get; set; }

        [StringLength(50)]
        public string student_politicsstatus { get; set; }

        [StringLength(20)]
        public string student_contact { get; set; }

        [StringLength(255)]
        public string student_family { get; set; }

        [StringLength(400)]
        public string student_award { get; set; }

        [StringLength(400)]
        public string student_other { get; set; }

        public int? status { get; set; }

        [StringLength(10)]
        public string yuliu1 { get; set; }

        [StringLength(10)]
        public string yuliu2 { get; set; }

        [StringLength(10)]
        public string yuliu3 { get; set; }

        public virtual Class Class { get; set; }

        public virtual College College { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_choosing> Course_choosing { get; set; }

        public virtual Major Major { get; set; }
    }
}
