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
        Task<bool> Create(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Update(T entity);
        Task<bool> Save();
    }
}
