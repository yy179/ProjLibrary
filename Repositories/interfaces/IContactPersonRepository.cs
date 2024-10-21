using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories.interfaces
{
    public interface IContactPersonRepository
    {
        Task<IEnumerable<ContactPersonEntity>> GetAllAsync();
        Task<ContactPersonEntity> GetByIdAsync(int id);
        Task AddAsync(ContactPersonEntity contactPerson);
        Task UpdateAsync(ContactPersonEntity contactPerson);
        Task DeleteAsync(int id);
    }
}
