using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class OsobaZad3 : IOsobaZad3
    {
        public OsobaZad3()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void GetFullName()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }

        public OsobaZad3(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
