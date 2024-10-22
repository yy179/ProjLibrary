using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity> GetByIdAsync(int id);
        Task<IEnumerable<UserEntity>> GetByRoleAsync(string role);
        Task AddAsync(UserEntity user);
        Task UpdateAsync(UserEntity user);
        Task DeleteAsync(int id);
    }
}
