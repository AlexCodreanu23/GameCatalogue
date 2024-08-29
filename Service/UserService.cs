using GameCatalogue.Models;
using GameCatalogue.Repositories;

namespace GameCatalogue.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUserByIdAsync(string id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public Task CreateUserAsync(User user)
        {
            return _userRepository.AddAsync(user);
        }

        public Task UpdateUserAsync(User user)
        {
            return _userRepository.UpdateAsync(user);
        }

        public Task DeleteUserAsync(string id)
        {
            return _userRepository.DeleteAsync(id);
        }
    }
}
