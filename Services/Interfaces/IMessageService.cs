﻿using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<MessageEntity>> GetMessagesReceivedByVolunteerAsync(int volunteerId);
        Task<MessageEntity> GetByIdAsync(int id);
        Task AddAsync(MessageEntity message);
        Task<List<MessageEntity>> GetMessagesSentByVolunteerAsync(int volunteerId);
        Task DeleteAsync(int id);
    }
}
