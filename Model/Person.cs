using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person
    {
        public string Ci { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Person()
        {

        }

        public Person(string ci, string name, string lastName, string secondLastName, char gender, DateTime birthDate)
        {
            Ci = ci;
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            Gender = gender;
            BirthDate = birthDate;
        }
        public Person(string ci)
        {
            Ci = ci;
        }
        public string GetInfo()
        {
            return Ci + " - " + Name + " - " + LastName + " - " + SecondLastName + " - " + Gender + " - " + BirthDate.ToShortDateString();
        }
    }
}
