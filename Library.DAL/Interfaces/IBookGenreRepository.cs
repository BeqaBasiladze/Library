using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    internal interface IBookGenreRepository : IBaseRepository<BookGenre>
    {
        Task<IEnumerable<BookGenre>> GetAllBookGenresAsync();
        Task<BookGenre> GetBookGenreByIdAsync(int id);

    }
}
