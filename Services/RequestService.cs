using ClassLibrary.Models;
using ClassLibrary.Repositories;
using ClassLibrary.Repositories.interfaces;
using ClassLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Azure.Core;
using ClassLibrary.Validators;

namespace ClassLibrary.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        public RequestService(IRequestRepository requestRepository) 
        { 
            _requestRepository = requestRepository;
        }
        public async Task<IEnumerable<RequestEntity>> GetAllAsync()
        {
            return await _requestRepository.GetAllAsync();
        }
        public async Task<RequestEntity> GetByIdAsync(int requestId)
        {
            var request = await _requestRepository.GetByIdAsync(requestId);
            if (request == null)
            {
                throw new ArgumentException($"Request with ID {requestId} not found.");
            }
            return request;
        }
        public async Task<IEnumerable<RequestEntity>> GetByStatusAsync(string status)
        {
            return await _requestRepository.GetByStatusAsync(status);
        }
        public async Task AddAsync(RequestEntity request)
        {
            ValidateRequest(request);
            await _requestRepository.AddAsync(request);
        }
        public async Task UpdateAsync(RequestEntity request)
        {
            ValidateRequest(request);
            await _requestRepository.UpdateAsync(request);
        }
        public async Task DeleteAsync(int requestId)
        {
            var request = await _requestRepository.GetByIdAsync(requestId);
            if (request == null)
            {
                throw new ArgumentException($"Request with ID {requestId} not found.");
            }
            await _requestRepository.DeleteAsync(requestId);
        }
        private void ValidateRequest(RequestEntity request)
        {
            var validator = new RequestValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }
}
