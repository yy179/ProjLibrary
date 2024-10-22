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
        Task<List<OrganizationEntity>> GetOrganizationsForVolunteer(int volunteerId);
        Task AddVolunteerToOrganization(int volunteerId, int organizationId);
        Task RemoveVolunteerFromOrganization(int volunteerId, int organizationId);
        Task<List<VolunteerEntity>> GetVolunteersForOrganization(int organizationId);
    }
}
