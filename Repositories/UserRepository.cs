using Microsoft.EntityFrameworkCore;
using YouTube_Clone.DTO;
using YouTube_Clone.Models;

namespace YouTube_Clone.Respository
{
    public class UserRespositoty : IUserRespositoty
    {
        private readonly AppDbContext _context;

        public UserRespositoty(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Select(u => new User
            {
                UserID = u.UserID,
                ClerkID = u.ClerkID,
                Name = u.Name,
                ImageURL = u.ImageURL
            }).ToList();
        }

        public async Task<bool> DeleteUserAsync(string clerkId)
        {
            // Tìm người dùng dựa trên ClerkID
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ClerkID == clerkId);
            if (user == null)
            {
                return false; // Người dùng không tồn tại
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true; // Xóa thành công
        }

        public async Task<bool> UpdateUserAsync(string clerkId, UpdateUserDTO updateUserDto)
        {
            var user = await _context.Users.FindAsync(clerkId);
            if (user == null)
            {
                return false; 
            }

            user.Name = updateUserDto.Name;
            user.ImageURL = updateUserDto.ImageURL ?? user.ImageURL;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}