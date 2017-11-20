namespace hubu.sgms.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("College")]
    public partial class College
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public College()
        {
            Course = new HashSet<Course>();
            Major = new HashSet<Major>();
            Student = new HashSet<Student>();
            Teacher_course = new HashSet<Teacher_course>();
            Teacher = new HashSet<Teacher>();
        }

        [Key]
        [StringLength(20)]
        public string college_id { get; set; }

        [Column(TypeName = "text")]
        public string name { get; set; }

        public int? sort { get; set; }

        public int? student_number { get; set; }

        public int? teacher_number { get; set; }

        public int? class_number { get; set; }

        [StringLength(10)]
        public string yuliu1 { get; set; }

        [StringLength(10)]
        public string yuliu2 { get; set; }

        [StringLength(10)]
        public string yuliu3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Major> Major { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher_course> Teacher_course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
