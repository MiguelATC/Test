using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Interface;
using Db4objects.Db4o;

namespace Implementation
{
    public class BranchOfficeImpl : IBranchOffice
    {
        public void Delete(BranchOffice t)
        {
            DBImplementation.DeleteObject<BranchOffice>(t);
        }

        public void Insert(BranchOffice t)
        {
            DBImplementation.Insert<BranchOffice>(t);
        }

        public List<BranchOffice> Select()
        {
            return DBImplementation.Select<BranchOffice>();
        }

        public void Update(BranchOffice b, BranchOffice r)
        {
            try
            {
                DBImplementation.Open();
                IObjectSet result = DBImplementation.db.QueryByExample(b);
                BranchOffice found = (BranchOffice)result.Next();
                found.Name = r.Name;
                found.Members = r.Members;
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
