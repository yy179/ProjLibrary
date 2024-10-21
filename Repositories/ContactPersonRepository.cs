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
    public class ContactPersonRepository : IContactPersonRepository
    {
        private readonly ProjDbContext _context;

        public ContactPersonRepository(ProjDbContext context)
        {
            _context = context;
        }

        public async Task<ContactPersonEntity> GetByIdAsync(int id)
        {
            return await _context.ContactPersons.FindAsync(id);
        }

        public async Task<IEnumerable<ContactPersonEntity>> GetAllAsync()
        {
            return await _context.ContactPersons.ToListAsync();
        }

        public async Task AddAsync(ContactPersonEntity contactPerson)
        {
            await _context.ContactPersons.AddAsync(contactPerson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContactPersonEntity contactPerson)
        {
            _context.ContactPersons.Update(contactPerson);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contactPerson = await _context.ContactPersons.FindAsync(id);
            if (contactPerson != null)
            {
                _context.ContactPersons.Remove(contactPerson);
                await _context.SaveChangesAsync();
            }
        }
    }

}
