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
    public class MilitaryUnitService : IMilitaryUnitService
    {
        private readonly IMilitaryUnitRepository _militaryUnitRepository;
        public MilitaryUnitService(IMilitaryUnitRepository militaryUnitRepository)
        {
            _militaryUnitRepository = militaryUnitRepository;
        }
        public async Task<IEnumerable<MilitaryUnitEntity>> GetAllAsync()
        {
            return await _militaryUnitRepository.GetAllAsync();
        }
        public async Task<MilitaryUnitEntity> GetByIdAsync(int militaryUnitId)
        {
            var militaryUnit = await _militaryUnitRepository.GetByIdAsync(militaryUnitId);
            if (militaryUnit == null)
            {
                throw new ArgumentException($"Military Unit with ID {militaryUnitId} not found.");
            }
            return militaryUnit;
        }
        public async Task<IEnumerable<RequestEntity>> GetCompletedRequests(int militaryUnitId)
        {
            return await _militaryUnitRepository.GetCompletedRequests(militaryUnitId);
        }

        public async Task<IEnumerable<RequestEntity>> GetActiveRequests(int militaryUnitId)
        {
            return await _militaryUnitRepository.GetActiveRequests(militaryUnitId);
        }
        public async Task<IEnumerable<ContactPersonEntity>> GetContactPersons(int militaryUnitId)
        {
            return await _militaryUnitRepository.GetContactPersons(militaryUnitId);
        }
        public async Task AddAsync(MilitaryUnitEntity militaryUnit)
        {
            ValidateMilitaryUnit(militaryUnit);
            await _militaryUnitRepository.AddAsync(militaryUnit);
        }
        public async Task UpdateAsync(MilitaryUnitEntity militaryUnit)
        {
            ValidateMilitaryUnit(militaryUnit);
            await _militaryUnitRepository.UpdateAsync(militaryUnit);
        }
        public async Task DeleteAsync(int militaryUnitId)
        {
            await _militaryUnitRepository.DeleteAsync(militaryUnitId);
        }
        private void ValidateMilitaryUnit(MilitaryUnitEntity militaryUnit)
        {
            var validator = new MilitaryUnitValidator();
            var result = validator.Validate(militaryUnit);
            if (!result.IsValid) 
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }
}
