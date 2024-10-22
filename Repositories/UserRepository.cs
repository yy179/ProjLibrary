using ClassLibrary.Models;
using ClassLibrary.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjDbContext _context;

        public UserRepository(ProjDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<IEnumerable<UserEntity>> GetByRoleAsync(string role)
        {
            return await _context.Users
                .Where(user => user.Role == role)
                .ToListAsync();
        }
        public async Task AddAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserEntity user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }

}
