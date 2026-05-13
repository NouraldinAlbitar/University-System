using System;

namespace ConsoleApp2
{
    public class Enrollments
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public Students Student { get; set; }

        public int CourseId { get; set; }
        public Courses Course { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public string Grade { get; set; } = "";
        public string Status { get; set; } = "";
    }
}