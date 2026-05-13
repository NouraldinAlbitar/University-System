using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Courses
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; } = "";
        public string CourseName { get; set; } = "";
        public string Description { get; set; } = "";
        public int Credits { get; set; }
        public string Department { get; set; } = "";
        public int TeacherId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Capacity { get; set; }

        public Teachers Teacher { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; } = new List<Enrollments>();
    }
}