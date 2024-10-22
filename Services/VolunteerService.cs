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
    public class VolunteerService : IVolunteerService
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerService(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        public async Task<IEnumerable<VolunteerEntity>> GetAllAsync()
        {
            return await _volunteerRepository.GetAllAsync();
        }

        public async Task<VolunteerEntity> GetByIdAsync(int volunteerId)
        {
            var volunteer = await _volunteerRepository.GetByIdAsync(volunteerId);
            if (volunteer == null)
            {
                throw new ArgumentException($"Volunteer with ID {volunteerId} not found.");
            }
            return volunteer;
        }

        public async Task<List<RequestEntity>> GetCompletedRequests(int volunteerId)
        {
            return await _volunteerRepository.GetCompletedRequests(volunteerId);
        }

        public async Task<List<RequestEntity>> GetActiveRequests(int volunteerId)
        {
            return await _volunteerRepository.GetActiveRequests(volunteerId);
        }

        public async Task<List<OrganizationEntity>> GetOrganizations(int volunteerId)
        {
            return await _volunteerRepository.GetOrganizations(volunteerId);
        }

        public async Task AddAsync(VolunteerEntity volunteer)
        {
            ValidateVolunteer(volunteer);
            await _volunteerRepository.AddAsync(volunteer);
        }

        public async Task UpdateAsync(VolunteerEntity volunteer)
        {
            ValidateVolunteer(volunteer);
            await _volunteerRepository.UpdateAsync(volunteer);
        }

        public async Task DeleteAsync(int volunteerId)
        {
            var volunteer = await _volunteerRepository.GetByIdAsync(volunteerId);
            if (volunteer == null)
            {
                throw new ArgumentException($"Volunteer with ID {volunteerId} not found.");
            }
            await _volunteerRepository.DeleteAsync(volunteerId);
        }

        private void ValidateVolunteer(VolunteerEntity volunteer)
        {
            var validator = new VolunteerValidator();
            var result = validator.Validate(volunteer);

            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }

}
