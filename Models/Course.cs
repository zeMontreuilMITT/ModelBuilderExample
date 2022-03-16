using System.ComponentModel.DataAnnotations;

namespace ModelBuilderDemo.Models
{
    public class Course
    {
        public string CourseNumber { get; set; }
        public string Title { get; set; }

        public ICollection<Student> AttendingStudents { get; set; }
        public ICollection<Student> AuditingStudents { get; set; }

        public Course()
        {
            AttendingStudents = new HashSet<Student>();
            AuditingStudents = new HashSet<Student>();
        }
    }
}
