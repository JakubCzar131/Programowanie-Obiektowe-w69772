using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public interface IStudent : IOsobaZad3
    {
        public string School { get; set; }
        public string Major { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }

        public string GetFullNameAndSchool();
    }
}
