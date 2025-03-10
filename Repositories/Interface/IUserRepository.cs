using YouTube_Clone.Models;
using System.Collections.Generic;
using YouTube_Clone.DTO;

namespace YouTube_Clone.Respository
{
    public interface IUserRespositoty
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
        Task<bool> DeleteUserAsync(string clerkId);
        Task<bool> UpdateUserAsync(string clerkId, UpdateUserDTO updateUserDto);
    }
}