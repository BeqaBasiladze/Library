using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IPositionRepository : IBaseRepository<Position>
    {
        Task<Position> GetPositionById(int id);
        Task<IEnumerable<Position>> GetAllPositions();
    }
}
