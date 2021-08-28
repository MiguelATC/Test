using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Transact
    {
        public string Code { get; set; }
        public Person People { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Description { get; set; }
        public Transact()
        {

        }

        public Transact(string code, Person people, DateTime registerDate, string description)
        {
            Code = code;
            People = people;
            RegisterDate = registerDate;
            Description = description;
        }
        public Transact(string code)
        {
            Code = code;
        }      
        public string GetData()
        {
            return Code + " - " + Description + " - " + RegisterDate + " - " + People.GetInfo();
        }
    }
}
