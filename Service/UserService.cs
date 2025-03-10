using Microsoft.EntityFrameworkCore;
using YouTube_Clone.DTO;
using YouTube_Clone.Models;
using YouTube_Clone.Respository;
using YouTube_Clone.Service.Interface;

namespace YouTube_Clone.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRespositoty _userRepository;

        public UserService(IUserRespositoty userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public async Task<bool> DeleteUserAsync(string clerkId)
        {
            return await _userRepository.DeleteUserAsync(clerkId);
        }

        public async Task<bool> UpdateUserAsync(string clerkId, UpdateUserDTO updateUserDto)
        {
            return await _userRepository.UpdateUserAsync(clerkId, updateUserDto);
        }
    }
}
