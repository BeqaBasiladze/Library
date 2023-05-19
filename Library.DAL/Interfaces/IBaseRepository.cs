using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        bool Create(T entity);
        bool Delete(T entity);
        void Delete(Expression<Func<T, bool>> expression);
        bool Update(T entity);
        bool Save();
    }
}
