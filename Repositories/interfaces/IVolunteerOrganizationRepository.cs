using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories.interfaces
{
    public interface IVolunteerOrganizationRepository
    {
        Task<IEnumerable<VolunteerOrganizationEntity>> GetAllAsync();
        Task<VolunteerOrganizationEntity> GetByIdAsync(int id);
        Task AddAsync(VolunteerOrganizationEntity volunteerOrganization);
        Task UpdateAsync(VolunteerOrganizationEntity volunteerOrganization);
        Task DeleteAsync(int id);
    }
}
