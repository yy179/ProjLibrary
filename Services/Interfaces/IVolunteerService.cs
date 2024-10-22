﻿using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Interfaces
{
    public interface IVolunteerService
    {
        Task<IEnumerable<VolunteerEntity>> GetAllAsync();
        Task<VolunteerEntity> GetByIdAsync(int volunteerId);
        Task<List<RequestEntity>> GetCompletedRequests(int volunteerId);
        Task<List<RequestEntity>> GetActiveRequests(int volunteerId);
        Task<List<OrganizationEntity>> GetOrganizations(int volunteerId);
        Task AddAsync(VolunteerEntity volunteer);
        Task UpdateAsync(VolunteerEntity volunteer);
        Task DeleteAsync(int volunteerId);
    }

}