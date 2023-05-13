using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        bool Create(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        bool Save();
    }
}
