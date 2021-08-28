using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Model;
using Db4objects.Db4o;

namespace Implementation
{
    public class PersonImpl : IPerson
    {
        public void Delete(Person t)
        {
            DBImplementation.DeleteObject<Person>(t);
        }

        public void Insert(Person t)
        {
            DBImplementation.Insert<Person>(t);
        }

        public List<Person> Select()
        {
            return DBImplementation.Select<Person>();
        }

        public Person SelectByCi(string ci)
        {            
            return DBImplementation.SelectObject<Person>(new Person(ci));
        }

        public void Update(Person b, Person r)
        {
            try
            {
                DBImplementation.Open();
                IObjectSet result = DBImplementation.db.QueryByExample(b);
                Person found = (Person)result.Next();
                found.Name = r.Name;
                found.LastName = r.LastName;
                found.SecondLastName = r.SecondLastName;
                found.Gender = r.Gender;
                found.BirthDate = r.BirthDate;
                DBImplementation.db.Store(found);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DBImplementation.db.Close();
            }
        }
    }
}
