using ClassLibrary.Models;
using ClassLibrary.Repositories.interfaces;
using ClassLibrary.Services.Interfaces;
using ClassLibrary.Validators;
using System;
using System.Collections.Generic;
using FluentValidation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<OrganizationEntity> GetByIdAsync(int organizationId)
        {
            return await _organizationRepository.GetByIdAsync(organizationId);
        }

        public async Task<IEnumerable<OrganizationEntity>> GetAllAsync()
        {
            return await _organizationRepository.GetAllAsync();
        }

        public async Task<List<RequestEntity>> GetCompletedRequestsAsync(int organizationId)
        {
            return await _organizationRepository.GetCompletedRequests(organizationId);
        }

        public async Task<List<RequestEntity>> GetActiveRequestsAsync(int organizationId)
        {
            return await _organizationRepository.GetActiveRequests(organizationId);
        }

        public async Task<List<VolunteerEntity>> GetVolunteersAsync(int organizationId)
        {
            return await _organizationRepository.GetVolunteers(organizationId);
        }

        public async Task AddAsync(OrganizationEntity organization)
        {
            ValidateOrganization(organization);
            await _organizationRepository.AddAsync(organization);
        }

        public async Task UpdateAsync(OrganizationEntity organization)
        {
            ValidateOrganization(organization);
            await _organizationRepository.UpdateAsync(organization);
        }

        public async Task DeleteAsync(int organizationId)
        {
            await _organizationRepository.DeleteAsync(organizationId);
        }

        private void ValidateOrganization(OrganizationEntity organization)
        {
            var validator = new OrganizationValidator();
            var result = validator.Validate(organization);

            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }
}
