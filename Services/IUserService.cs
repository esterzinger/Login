using Entity;
using Repositories;

namespace Services
{
    public interface IUserService
    {
        public IEnumerable<string> GetAllUsers();


        // GET api/<UserController>/5

        public User GetUserById(int id);
       

        // POST api/<UserController>

        public User CreatUser(User user);


        public User Login(User detailsofuser);



        // PUT api/<UserController>/5

        public void UpdateUserById(int id, User userToUpdate);


        // DELETE api/<UserController>/
        public void Delete(int id);
       
    

}
}