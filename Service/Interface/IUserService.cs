using YouTube_Clone.DTO;
using YouTube_Clone.Models;

namespace YouTube_Clone.Service.Interface
{
    public interface IUserService
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
        Task<bool> DeleteUserAsync(string clerkId);
        Task<bool> UpdateUserAsync(string clerkId, UpdateUserDTO updateUserDto);
    }
}
