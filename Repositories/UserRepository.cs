using Entity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        EsterChaniContext _EsterChaniContext;
        public UserRepository(EsterChaniContext EsterTziviContext)
        {
            _EsterChaniContext = EsterTziviContext;
        }
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5

        public async Task<User> GetUserById(int id)
        {
            User user = await _EsterChaniContext.Users.FindAsync(id);

            return user; //write in c# code
            return null;


        }

        // POST api/<UserController>

        public async Task<User> CreatUser(User user)
        {
            await _EsterChaniContext.Users.AddAsync(user);
            await _EsterChaniContext.SaveChangesAsync();

            return user;

            //CreatedAtAction(nameof(Get), new { id = user.Id }, user);


        }

        public async Task<User> Login(User detailsofuser)
        {


            var user = await _EsterChaniContext.Users.Where(users => detailsofuser.Password == users.Password & detailsofuser.Email == users.Email).ToListAsync();
            if (user != null)
                return user[0];
            return null;


        }


        //PUT api/<UserController>/5

        public async Task<User> UpdateUserById(int id, User userToUpdate)
        {

            var user = await _EsterChaniContext.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            _EsterChaniContext.Entry(user).CurrentValues.SetValues(userToUpdate);
            await _EsterChaniContext.SaveChangesAsync();
            return userToUpdate;


        }

        // DELETE api/<UserController>/
        public async Task Delete(int id)
        {
            var user = await _EsterChaniContext.Users.FindAsync(id);
            if (user != null)
            {
                _EsterChaniContext.Users.Remove(user);
                _EsterChaniContext.SaveChanges();
            }
        }


    }
}