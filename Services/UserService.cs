using Entity;
using Repositories;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Services
{
    public class UserService:IUserService

    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> GetAllUsers()
            
        {
            return new string[] { "value1", "value2" };
            //UserRepository.Get();

        }

        // GET api/<UserController>/5

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
           

        }

        // POST api/<UserController>

        public User CreatUser(User user)
        {
            return _userRepository.CreatUser(user);
            

        }

        public User Login(User detailsofuser)
        {
            return _userRepository.Login(detailsofuser);
            


        }


        // PUT api/<UserController>/5

        public void UpdateUserById(int id, User userToUpdate)
        {
            _userRepository.UpdateUserById(id, userToUpdate);
           

        }

        // DELETE api/<UserController>/
        public void Delete(int id)
        {

        }
    }

    
}