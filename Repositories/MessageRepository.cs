﻿using ClassLibrary.Models;
using ClassLibrary.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ProjDbContext _context;

        public MessageRepository(ProjDbContext context)
        {
            _context = context;
        }

        public async Task<MessageEntity> GetByIdAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task AddAsync(MessageEntity message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
        public async Task<List<MessageEntity>> GetMessagesSentByVolunteerAsync(int volunteerId)
        {
            return await _context.Messages
                .Where(m => m.FromVolunteerId == volunteerId)
                .ToListAsync();
        }
        public async Task<List<MessageEntity>> GetMessagesReceivedByVolunteerAsync(int volunteerId)
        {
            return await _context.Messages
                .Where(m => m.ToVolunteerId == volunteerId)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
            }
        }
    }

}
