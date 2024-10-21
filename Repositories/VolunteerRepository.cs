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
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly ProjDbContext _context;

        public VolunteerRepository(ProjDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VolunteerEntity>> GetAllAsync()
        {
            return await _context.Volunteers.ToListAsync();
        }

        public async Task<VolunteerEntity> GetByIdAsync(int id)
        {
            return await _context.Volunteers.FindAsync(id);
        }

        public async Task AddAsync(VolunteerEntity volunteer)
        {
            await _context.Volunteers.AddAsync(volunteer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VolunteerEntity volunteer)
        {
            _context.Volunteers.Update(volunteer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Volunteers.FindAsync(id);
            if (entity != null)
            {
                _context.Volunteers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
