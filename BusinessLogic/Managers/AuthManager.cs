using CafeClient.DataAccess.Repositories;
using CafeClient.BusinessLogic.Models;

namespace CafeClient.BusinessLogic.Managers
{
    public class AuthManager
    {
        private readonly UserRepository _userRepository;

        public AuthManager()
        {
            _userRepository = new UserRepository();
        }

        public User Login(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user != null && user.PasswordHash == HashPassword(password))
                return user;
            return null;
        }

        public bool IsInRole(User user, string role) => user.Role == role;

        private string HashPassword(string password)
        {
            // Implement a secure hash function
            return password; // Placeholder
        }
    }
}
