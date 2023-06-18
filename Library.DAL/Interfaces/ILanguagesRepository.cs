using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface ILanguagesRepository
    {
        Task<Language> GetLangeageById(int id);
        Task<IEnumerable<MenuItem>> GetAllLanguages();
        void AddMenuItem(MenuItem menuItem);
        void UpdateMenuItem(MenuItem menuItem);
        void DeleteMenuItem(MenuItem menuItem);
    }
}
