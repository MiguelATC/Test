using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Interface
{
    public interface IPerson:IDao<Person>
    {
        Person SelectByCi(string ci);
    }
}
