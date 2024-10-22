using ClassLibrary.Models;
using ClassLibrary.Repositories.interfaces;
using ClassLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class VolunteerOrganizationService : IVolunteerOrganizationService
    {
        private readonly IVolunteerOrganizationRepository _volunteerOrganizationRepository;
        private readonly IVolunteerService _volunteerService;
        private readonly IOrganizationService _organizationService;

        public VolunteerOrganizationService(
            IVolunteerOrganizationRepository volunteerOrganizationRepository,
            IVolunteerService volunteerService,
            IOrganizationService organizationService)
        {
            _volunteerOrganizationRepository = volunteerOrganizationRepository;
            _volunteerService = volunteerService;
            _organizationService = organizationService;
        }

        public async Task<List<OrganizationEntity>> GetOrganizationsForVolunteerAsync(int volunteerId)
        {
            var volunteer = await _volunteerService.GetByIdAsync(volunteerId);
            if (volunteer == null)
                throw new ArgumentException("Volunteer not found");

            return await _volunteerOrganizationRepository.GetOrganizationsForVolunteer(volunteerId);
        }

        public async Task<List<VolunteerEntity>> GetVolunteersForOrganizationAsync(int organizationId)
        {
            var organization = await _organizationService.GetByIdAsync(organizationId);
            if (organization == null)
                throw new ArgumentException("Organization not found");

            return await _volunteerOrganizationRepository.GetVolunteersForOrganization(organizationId);
        }

        public async Task AddVolunteerToOrganizationAsync(int volunteerId, int organizationId)
        {
            var volunteer = await _volunteerService.GetByIdAsync(volunteerId);
            if (volunteer == null)
                throw new ArgumentException("Volunteer not found");


            var organization = await _organizationService.GetByIdAsync(organizationId);
            if (organization == null)
                throw new ArgumentException("Organization not found");


            var existingVolunteers = await _volunteerOrganizationRepository.GetVolunteersForOrganization(organizationId);
            if (existingVolunteers.Any(v => v.Id == volunteerId))
                throw new InvalidOperationException("Volunteer is already part of the organization");

            await _volunteerOrganizationRepository.AddVolunteerToOrganization(volunteerId, organizationId);
        }

        public async Task RemoveVolunteerFromOrganizationAsync(int volunteerId, int organizationId)
        {
            var volunteersInOrganization = await _volunteerOrganizationRepository.GetVolunteersForOrganization(organizationId);
            if (!volunteersInOrganization.Any(v => v.Id == volunteerId))
                throw new ArgumentException("The volunteer is not part of this organization");

            await _volunteerOrganizationRepository.RemoveVolunteerFromOrganization(volunteerId, organizationId);
        }
    }
}

