using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructủe
{
    public interface IRepository <T> where T: class
    {
        T Add(T entity);
        void Update(T entity);
        T Delete(int id);
        T Delete(T entity);
        IEnumerable<T> GetAll(string[] includes = null);
        T GetById(int id);
    }
}
