using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Students
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public int Age { get; set; }
        public string Gender { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Address { get; set; } = "";
        public string Department { get; set; } = "";
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollments> Enrollments { get; set; } = new List<Enrollments>();
    }
}