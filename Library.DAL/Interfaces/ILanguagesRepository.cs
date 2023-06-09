﻿using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface ILanguagesRepository : IBaseRepository<Language>
    {
        Task<Language> GetLangeageById(int id);
        Task<IEnumerable<Language>> GetAllLanguages();
    }
}
