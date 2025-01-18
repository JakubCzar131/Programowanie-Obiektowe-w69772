using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Uczen : Osoba
    {
        protected bool canGoHomeAlone;
        protected string school;
        public string School
        {
            get
            {
                return school;
            }
        }
        public bool CanGoHomeAlone
        {
            get
            {
                return canGoHomeAlone;
            }
        }

        public void SetSchool(string school)
        {
            if (this.school.Length > 0)
            {
                throw new ArgumentException("szkoła już jest");
            }
            else this.school = school;
        }
        public void ChangeSchool(string school)
        {
            if (this.school.Length == 0)
            {
                throw new ArgumentException("najpierw ustaw szkołę");
            }
            else this.school = school;
        }

        public void SetCanGoHomeAlone(bool canGoHomeAlone)
        {
            if (GetAge() < 12)
            {
                throw new ArgumentException("nie można ustawić - uczeń musi mieć min. 12 lat");
            }
            else
                this.canGoHomeAlone = canGoHomeAlone;
        }

        public override void GetEducationInfo()
        {
            Console.WriteLine($"Szkoła: {school}");
        }

        public override void CanGoAloneToHome()
        {
            Console.WriteLine(canGoHomeAlone ? "Może sam iść do domu" : "Nie Może sam iść do domu");
        }

        public Uczen(string firstName, string lastName, string pesel, string school) : base(firstName, lastName, pesel)
        {
            this.canGoHomeAlone = GetAge() > 12;
            this.school = school;
        }
    }
}
