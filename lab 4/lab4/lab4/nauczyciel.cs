using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Nauczyciel : Uczen
    {
        public string AcademicTitle { get; set; }
        public List<Uczen> ResponsibleStudents { get; set; }

        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        {
            ResponsibleStudents.ForEach(student =>
            {
                if (student.GetAge(dateToCheck) > 12) student.GetFullName();
            });
        }

        public Nauczyciel(string firstName, string lastName, string pesel, string school, string academicTitle, List<Uczen> responsibleStudents) : base(firstName, lastName, pesel, school)
        {
            AcademicTitle = academicTitle;
            ResponsibleStudents = responsibleStudents;
            canGoHomeAlone = true;
        }
    }

}
