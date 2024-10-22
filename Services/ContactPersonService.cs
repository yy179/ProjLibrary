using ClassLibrary.Models;
using ClassLibrary.Repositories;
using ClassLibrary.Repositories.interfaces;
using ClassLibrary.Services.Interfaces;
using ClassLibrary.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class ContactPersonService : IContactPersonService
    {
        private readonly IContactPersonRepository _contactPersonRepository;

        public ContactPersonService(IContactPersonRepository contactPersonRepository)
        {
            _contactPersonRepository = contactPersonRepository;
        }
        public async Task<IEnumerable<ContactPersonEntity>> GetAllAsync()
        {
            return await _contactPersonRepository.GetAllAsync();
        }
        public async Task<ContactPersonEntity> GetByIdAsync(int contactPersonId)
        {
            var contactPerson = await _contactPersonRepository.GetByIdAsync(contactPersonId);
            if (contactPerson == null)
            {
                throw new ArgumentException($"Volunteer with ID {contactPersonId} not found.");
            }
            return contactPerson;
        }
        public async Task<IEnumerable<ContactPersonEntity>> GetByMilitaryUnitId(int militaryUnitId)
        {
            var militaryUnit = await _contactPersonRepository.GetByMilitaryUnitId(militaryUnitId);
            if (militaryUnit == null)
            {
                throw new ArgumentException($"Volunteer with ID {militaryUnitId} not found.");
            }
            return await _contactPersonRepository.GetByMilitaryUnitId(militaryUnitId);
        }
        public async Task AddAsync(ContactPersonEntity contactPerson)
        {
            ValidateContactPerson(contactPerson);
            await _contactPersonRepository.AddAsync(contactPerson);
        }
        public async Task UpdateAsync(ContactPersonEntity contactPerson)
        {
            ValidateContactPerson(contactPerson);
            await _contactPersonRepository.UpdateAsync(contactPerson);
        }
        public async Task DeleteAsync(int contactPersonId)
        {
            var volunteer = await _contactPersonRepository.GetByIdAsync(contactPersonId);
            if (volunteer == null)
            {
                throw new ArgumentException($"Volunteer with ID {contactPersonId} not found.");
            }
            await _contactPersonRepository.DeleteAsync(contactPersonId);
        }

        private void ValidateContactPerson(ContactPersonEntity contactPerson)
        {
            var validator = new ContactPersonValidator();
            var result = validator.Validate(contactPerson);

            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }
}
