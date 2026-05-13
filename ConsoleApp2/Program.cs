using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static AppDbContext db = new AppDbContext();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Teachers");
                Console.WriteLine("3. Courses");
                Console.WriteLine("4. Enroll Student");
                Console.WriteLine("0. Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": StudentsMenu(); break;
                    case "2": TeachersMenu(); break;
                    case "3": CoursesMenu(); break;
                    case "4": EnrollStudent(); break;
                    case "0": return;
                }
            }
        }

        static void StudentsMenu()
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            var c = Console.ReadLine();
            if (c == "1") AddStudent();
            if (c == "2") ViewStudents();
        }

        static void AddStudent()
        {
            var s = new Students();
            Console.Write("Full Name: ");
            s.FullName = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            s.Email = Console.ReadLine() ?? "";

            Console.Write("Age (1-100): ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0 || age > 100)
            {
                Console.WriteLine("Invalid age. Must be between 1 and 100.");
                return;
            }
            s.Age = age;

            Console.Write("Gender: ");
            s.Gender = Console.ReadLine() ?? "";

            Console.Write("Phone Number: ");
            s.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Address: ");
            s.Address = Console.ReadLine() ?? "";

            Console.Write("Department: ");
            s.Department = Console.ReadLine() ?? "";

            s.EnrollmentDate = DateTime.UtcNow;

            db.Students.Add(s);
            db.SaveChanges();
            Console.WriteLine("Student added successfully!");
        }

        static void ViewStudents()
        {
            var students = db.Students.ToList();
            if (!students.Any())
            {
                Console.WriteLine("No students found.");
                return;
            }
            foreach (var s in students)
                Console.WriteLine($"{s.StudentId} - {s.FullName} - {s.Email} - Age: {s.Age}");
        }

        static void TeachersMenu()
        {
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. View Teachers");
            var c = Console.ReadLine();
            if (c == "1") AddTeacher();
            if (c == "2") ViewTeachers();
        }

        static void AddTeacher()
        {
            var t = new Teachers();

            Console.Write("Full Name: ");
            t.FullName = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            t.Email = Console.ReadLine() ?? "";

            Console.Write("Phone Number: ");
            t.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Specialization: ");
            t.Specialization = Console.ReadLine() ?? "";

            Console.Write("Department: ");
            t.Department = Console.ReadLine() ?? "";

            Console.Write("Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary) || salary < 0)
            {
                Console.WriteLine("Invalid salary.");
                return;
            }
            t.Salary = salary;

            t.HireDate = DateTime.UtcNow;

            db.Teachers.Add(t);
            db.SaveChanges();
            Console.WriteLine("Teacher added successfully!");
        }

        static void ViewTeachers()
        {
            var teachers = db.Teachers.ToList();
            if (!teachers.Any())
            {
                Console.WriteLine("No teachers found.");
                return;
            }
            foreach (var t in teachers)
                Console.WriteLine($"{t.TeacherId} - {t.FullName} - {t.Email} - {t.Department}");
        }

        static void CoursesMenu()
        {
            Console.WriteLine("1. Add Course");
            Console.WriteLine("2. View Courses");
            var c = Console.ReadLine();
            if (c == "1") AddCourse();
            if (c == "2") ViewCourses();
        }

        static void AddCourse()
        {
            var c = new Courses();

            Console.Write("Course Name: ");
            c.CourseName = Console.ReadLine() ?? "";

            Console.Write("Course Code: ");
            c.CourseCode = Console.ReadLine() ?? "";

            Console.Write("Description: ");
            c.Description = Console.ReadLine() ?? "";

            Console.Write("Credits: ");
            if (!int.TryParse(Console.ReadLine(), out int credits) || credits <= 0)
            {
                Console.WriteLine("Invalid credits.");
                return;
            }
            c.Credits = credits;

            Console.Write("Department: ");
            c.Department = Console.ReadLine() ?? "";

            Console.Write("Capacity: ");
            if (!int.TryParse(Console.ReadLine(), out int capacity) || capacity <= 0)
            {
                Console.WriteLine("Invalid capacity.");
                return;
            }
            c.Capacity = capacity;

            Console.Write("Teacher ID: ");
            if (!int.TryParse(Console.ReadLine(), out int teacherId))
            {
                Console.WriteLine("Invalid Teacher ID.");
                return;
            }
            var teacher = db.Teachers.Find(teacherId);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }
            c.TeacherId = teacherId;

            c.StartDate = DateTime.UtcNow;
            c.EndDate = DateTime.UtcNow.AddMonths(6);

            db.Courses.Add(c);
            db.SaveChanges();
            Console.WriteLine("Course added successfully!");
        }

        static void ViewCourses()
        {
            var courses = db.Courses.ToList();
            if (!courses.Any())
            {
                Console.WriteLine("No courses found.");
                return;
            }
            foreach (var c in courses)
                Console.WriteLine($"{c.CourseId} - {c.CourseName} - {c.CourseCode} - {c.Department}");
        }

        static void EnrollStudent()
        {
            Console.Write("Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int sid))
            {
                Console.WriteLine("Invalid Student ID.");
                return;
            }

            Console.Write("Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int cid))
            {
                Console.WriteLine("Invalid Course ID.");
                return;
            }

            var student = db.Students.Find(sid);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            var course = db.Courses.Find(cid);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            var exists = db.Enrollments.Any(e => e.StudentId == sid && e.CourseId == cid);
            if (exists)
            {
                Console.WriteLine("Student is already enrolled in this course!");
                return;
            }

            var enrollment = new Enrollments
            {
                StudentId = sid,
                CourseId = cid,
                EnrollmentDate = DateTime.UtcNow,
                Grade = "N/A",
                Status = "Active"
            };

            db.Enrollments.Add(enrollment);
            db.SaveChanges();
            Console.WriteLine("Student enrolled successfully!");
        }
    }
}