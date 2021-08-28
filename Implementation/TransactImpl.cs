using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Model;

namespace Implementation
{
    public class TransactImpl : ITransact
    {
        public void Delete(Transact t)
        {
            DBImplementation.DeleteObject<Transact>(t);
        }

        public void Insert(Transact t)
        {
            DBImplementation.Insert<Transact>(t);
        }

        public List<Transact> Select()
        {
            return DBImplementation.Select<Transact>();
        }

        public Transact SelectByCode(string code)
        {
            return DBImplementation.SelectObject<Transact>(new Transact(code));
        }

        public void Update(Transact b, Transact r)
        {
            throw new NotImplementedException();
        }
    }
}
