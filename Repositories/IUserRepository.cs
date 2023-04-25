using Entity;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> CreatUser(User user);
        Task Delete(int id);
        IEnumerable<string> GetAll();
        Task<User> GetUserById(int id);
        Task<User> Login(User detailsofuser);
        Task<User> UpdateUserById(int id, User userToUpdate);
    }
}