using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories.interfaces
{
    public interface IMilitaryUnitRepository
    {
        Task<IEnumerable<MilitaryUnitEntity>> GetAllAsync();
        Task<MilitaryUnitEntity> GetByIdAsync(int militaryUnitId);
        Task<IEnumerable<RequestEntity>> GetActiveRequests(int militaryUnitId);
        Task<IEnumerable<RequestEntity>> GetCompletedRequests(int militaryUnitId);
        Task<IEnumerable<ContactPersonEntity>> GetContactPersons(int militaryUnitId);
        Task AddAsync(MilitaryUnitEntity militaryUnit);
        Task UpdateAsync(MilitaryUnitEntity militaryUnit);
        Task DeleteAsync(int militaryUnitId);
    }
}
