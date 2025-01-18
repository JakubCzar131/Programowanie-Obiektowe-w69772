using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Student : IStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string School { get; set; }
        public string Major { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public string GetFullNameAndSchool()
        {
            return $"{FirstName} {LastName} - {Semester}{Major} {Year} {School}";
        }

        public void GetFullName()
        {
            Console.WriteLine($"{FirstName} {LastName} - {Semester}{Major} {Year} {School}");
        }

        public Student(string firstName, string lastName, string school, string major, int year, int semester)
        {
            FirstName = firstName;
            LastName = lastName;
            School = school;
            Major = major;
            Year = year;
            Semester = semester;
        }
    }
}
