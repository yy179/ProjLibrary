﻿using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories.interfaces
{
    public interface IRequestRepository
    {
        Task<IEnumerable<RequestEntity>> GetAllAsync();
        Task<RequestEntity> GetByIdAsync(int id);
        Task AddAsync(RequestEntity request);
        Task UpdateAsync(RequestEntity request);
        Task DeleteAsync(int id);
    }
}
