using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelBuilderDemo.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }   
        public string FullName { get; set; }

        public string AttendingCourseNumber { get; set; }
        public Course AttendingCourse { get; set; }


        public string AuditingCourseNumber { get; set; }
        public Course AuditingCourse { get; set; }

    }
}
