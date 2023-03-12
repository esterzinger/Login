using Entity;

namespace Repositories
{
    public interface IUserRepository
    {
        User CreatUser(User user);
        void Delete(int id);
        IEnumerable<string> GetAll();
        User GetUserById(int id);
        User Login(User detailsofuser);
        void UpdateUserById(int id, User userToUpdate);
    }
}