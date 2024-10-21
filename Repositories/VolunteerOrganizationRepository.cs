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
    public class VolunteerOrganizationRepository : IVolunteerOrganizationRepository
    {
        private readonly ProjDbContext _context;

        public VolunteerOrganizationRepository(ProjDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VolunteerOrganizationEntity>> GetAllAsync()
        {
            return await _context.VolunteerOrganizations.ToListAsync();
        }

        public async Task<VolunteerOrganizationEntity> GetByIdAsync(int id)
        {
            return await _context.VolunteerOrganizations.FindAsync(id);
        }

        public async Task AddAsync(VolunteerOrganizationEntity volunteerOrganization)
        {
            await _context.VolunteerOrganizations.AddAsync(volunteerOrganization);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VolunteerOrganizationEntity volunteerOrganization)
        {
            _context.VolunteerOrganizations.Update(volunteerOrganization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.VolunteerOrganizations.FindAsync(id);
            if (entity != null)
            {
                _context.VolunteerOrganizations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
