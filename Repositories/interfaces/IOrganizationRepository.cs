using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories.interfaces
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<OrganizationEntity>> GetAllAsync();
        Task<OrganizationEntity> GetByIdAsync(int id);
        Task AddAsync(OrganizationEntity organization);
        Task UpdateAsync(OrganizationEntity organization);
        Task DeleteAsync(int id);
    }
}
