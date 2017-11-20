namespace hubu.sgms.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teacher")]
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            Class = new HashSet<Class>();
            Course_choosing = new HashSet<Course_choosing>();
            Teacher_course = new HashSet<Teacher_course>();
        }

        [Key]
        [StringLength(20)]
        public string teacher_id { get; set; }

        [StringLength(50)]
        public string teacher_name { get; set; }

        [StringLength(10)]
        public string teachert_sex { get; set; }

        [StringLength(20)]
        public string teacher_id_card { get; set; }

        public int? teachert_age { get; set; }

        [StringLength(255)]
        public string teacher_department { get; set; }

        [StringLength(20)]
        public string college_id { get; set; }

        [StringLength(100)]
        public string teacher_title { get; set; }

        [StringLength(100)]
        public string teacher_native { get; set; }

        [StringLength(255)]
        public string teacher_birthplace { get; set; }

        [StringLength(400)]
        public string teacher_photo { get; set; }

        [StringLength(50)]
        public string teacher_politicsstatus { get; set; }

        [StringLength(50)]
        public string teacher_teachingtime { get; set; }

        [StringLength(20)]
        public string teacher_contact { get; set; }

        [StringLength(400)]
        public string teacher_other { get; set; }

        public int? status { get; set; }

        [StringLength(10)]
        public string yuliu1 { get; set; }

        [StringLength(10)]
        public string yuliu2 { get; set; }

        [StringLength(10)]
        public string yuliu3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class> Class { get; set; }

        public virtual College College { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_choosing> Course_choosing { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher_course> Teacher_course { get; set; }
    }
}
