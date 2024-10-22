using ClassLibrary.Models;
using ClassLibrary.Repositories.interfaces;
using ClassLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new ArgumentException("User not found");

            return user;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetByRoleAsync(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role cannot be empty");

            return await _userRepository.GetByRoleAsync(role);
        }

        public async Task AddAsync(UserEntity user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Username cannot be empty");

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new ArgumentException("Password cannot be empty");

            if (string.IsNullOrWhiteSpace(user.Role))
                throw new ArgumentException("Role cannot be empty");

            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(UserEntity user)
        {
            var existingUser = await _userRepository.GetByIdAsync(user.Id);
            if (existingUser == null)
                throw new ArgumentException("User not found");

            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Username cannot be empty");

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new ArgumentException("Password cannot be empty");

            if (string.IsNullOrWhiteSpace(user.Role))
                throw new ArgumentException("Role cannot be empty");

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new ArgumentException("User not found");

            await _userRepository.DeleteAsync(id);
        }
    }
}
