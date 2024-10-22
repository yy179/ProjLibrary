using ClassLibrary.Models;
using ClassLibrary.Repositories.interfaces;
using ClassLibrary.Services.Interfaces;
using ClassLibrary.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ClassLibrary.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IVolunteerService _volunteerService;

        public MessageService(IMessageRepository messageRepository, IVolunteerService volunteerService)
        {
            _messageRepository = messageRepository;
            _volunteerService = volunteerService;
        }

        public async Task<MessageEntity> GetByIdAsync(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);
            if (message == null)
                throw new ArgumentException("Message not found");

            return message;
        }
        public async Task<List<MessageEntity>> GetMessagesSentByVolunteerAsync(int volunteerId)
        {
            var volunteer = await _volunteerService.GetByIdAsync(volunteerId);
            if (volunteer == null)
                throw new ArgumentException("Volunteer not found");

            return await _messageRepository.GetMessagesSentByVolunteerAsync(volunteerId);
        }

        public async Task<List<MessageEntity>> GetMessagesReceivedByVolunteerAsync(int volunteerId)
        {
            var volunteer = await _volunteerService.GetByIdAsync(volunteerId);
            if (volunteer == null)
                throw new ArgumentException("Volunteer not found");

            return await _messageRepository.GetMessagesReceivedByVolunteerAsync(volunteerId);
        }

        public async Task AddAsync(MessageEntity message)
        {
            var fromVolunteer = await _volunteerService.GetByIdAsync(message.FromVolunteerId);
            if (fromVolunteer == null)
                throw new ArgumentException("Sender volunteer not found");

            var toVolunteer = await _volunteerService.GetByIdAsync(message.ToVolunteerId);
            if (toVolunteer == null)
                throw new ArgumentException("Recipient volunteer not found");

            ValidateMessage(message);
            await _messageRepository.AddAsync(message);
        }

        public async Task DeleteAsync(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);
            if (message == null)
                throw new ArgumentException("Message not found");

            await _messageRepository.DeleteAsync(id);
        }
        private void ValidateMessage(MessageEntity message)
        {
            var validator = new MessageValidator();
            var result = validator.Validate(message);

            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }
}

