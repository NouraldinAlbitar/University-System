using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Teachers
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Specialization { get; set; } = "";
        public string Department { get; set; } = "";
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public ICollection<Courses> Courses { get; set; } = new List<Courses>();
    }
}