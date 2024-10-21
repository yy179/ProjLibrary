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
    public class MilitaryUnitRepository : IMilitaryUnitRepository
    {
        private readonly ProjDbContext _context;

        public MilitaryUnitRepository(ProjDbContext context)
        {
            _context = context;
        }

        public async Task<MilitaryUnitEntity> GetByIdAsync(int id)
        {
            return await _context.MilitaryUnits.FindAsync(id);
        }

        public async Task<IEnumerable<MilitaryUnitEntity>> GetAllAsync()
        {
            return await _context.MilitaryUnits.ToListAsync();
        }

        public async Task AddAsync(MilitaryUnitEntity militaryUnit)
        {
            await _context.MilitaryUnits.AddAsync(militaryUnit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MilitaryUnitEntity militaryUnit)
        {
            _context.MilitaryUnits.Update(militaryUnit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var militaryUnit = await _context.MilitaryUnits.FindAsync(id);
            if (militaryUnit != null)
            {
                _context.MilitaryUnits.Remove(militaryUnit);
                await _context.SaveChangesAsync();
            }
        }
    }

}
