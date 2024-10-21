using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories.interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<MessageEntity>> GetAllAsync();
        Task<MessageEntity> GetByIdAsync(int id);
        Task AddAsync(MessageEntity message);
        Task UpdateAsync(MessageEntity message);
        Task DeleteAsync(int id);
    }
}
