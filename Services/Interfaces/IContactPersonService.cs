using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Interfaces
{
    public interface IContactPersonService
    {
        Task<IEnumerable<ContactPersonEntity>> GetAllAsync();
        Task<ContactPersonEntity> GetByIdAsync(int contactPersonId);
        Task<IEnumerable<ContactPersonEntity>> GetByMilitaryUnitId(int militaryUnitId);
        Task AddAsync(ContactPersonEntity contactPerson);
        Task UpdateAsync(ContactPersonEntity contactPerson);
        Task DeleteAsync(int contactPersonId);
    }
}
