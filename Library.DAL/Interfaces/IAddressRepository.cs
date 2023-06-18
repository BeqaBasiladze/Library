using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<Address> GetAddressById(int id);
        Task<IEnumerable<Address>> GetAllAddresses();
    }
}
