using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Interfaces
{
    public interface IRequestService
    {
        Task<IEnumerable<RequestEntity>> GetAllAsync();
        Task<RequestEntity> GetByIdAsync(int requestId);
        Task<IEnumerable<RequestEntity>> GetByStatusAsync(string status);
        Task AddAsync(RequestEntity request);
        Task UpdateAsync(RequestEntity request);
        Task DeleteAsync(int requestId);
    }
}
