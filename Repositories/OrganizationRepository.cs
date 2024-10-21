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
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ProjDbContext _context;

        public OrganizationRepository(ProjDbContext context)
        {
            _context = context;
        }

        public async Task<OrganizationEntity> GetByIdAsync(int id)
        {
            return await _context.Organizations.FindAsync(id);
        }

        public async Task<IEnumerable<OrganizationEntity>> GetAllAsync()
        {
            return await _context.Organizations.ToListAsync();
        }

        public async Task AddAsync(OrganizationEntity organization)
        {
            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrganizationEntity organization)
        {
            _context.Organizations.Update(organization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization != null)
            {
                _context.Organizations.Remove(organization);
                await _context.SaveChangesAsync();
            }
        }
    }

}
