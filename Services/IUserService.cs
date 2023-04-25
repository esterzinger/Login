using Entity;
using Repositories;

namespace Services
{
    public interface IUserService
    {
        public IEnumerable<string> GetAllUsers();


        // GET api/<UserController>/5

        public Task<User> GetUserById(int id);
       

        // POST api/<UserController>

        public Task<User> CreatUser(User user);


        public Task<User> Login(User detailsofuser);



        // PUT api/<UserController>/5

       public Task UpdateUserById(int id, User userToUpdate);


        // DELETE api/<UserController>/
        public Task Delete(int id);
       
    

}
}