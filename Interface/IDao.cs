using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IDao<T>
    {
        void Insert(T t);
        List<T> Select();
        void Delete(T t);
        void Update(T b, T r);
    }
}
