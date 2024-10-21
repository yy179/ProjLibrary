using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories.interfaces
{
    public interface IVolunteerRepository
    {
        Task<IEnumerable<VolunteerEntity>> GetAllAsync();
        Task<VolunteerEntity> GetByIdAsync(int id);
        Task AddAsync(VolunteerEntity volunteer);
        Task UpdateAsync(VolunteerEntity volunteer);
        Task DeleteAsync(int id);
    }

}
