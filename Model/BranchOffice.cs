using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BranchOffice
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Person> Members { get; set; }
        public BranchOffice()
        {

        }
        public BranchOffice(string code, string name, List<Person> members)
        {
            Code = code;
            Name = name;
            Members = members;
        }
    }
}
