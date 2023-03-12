using Entity;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository :  IUserRepository
    {
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5

        public User GetUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText("./users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return user; //TO CLIENTwrite in c# code
                }
            }
            return null; //write in c# code

        }

        // POST api/<UserController>

        public User CreatUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines("./users.txt").Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("./users.txt", userJson + Environment.NewLine);
            return user;

            //CreatedAtAction(nameof(Get), new { id = user.Id }, user);


        }

        public User Login(User detailsofuser)
        {
            using (StreamReader reader = System.IO.File.OpenText("./users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Console.Write(currentUserInFile);
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    Console.Write(user);
                    if (user.Email == detailsofuser.Email && user.Password == detailsofuser.Password)
                        return user;
                }
            }
            return null;


        }


        // PUT api/<UserController>/5

        public void UpdateUserById(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("./users.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("./users.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText("./users.txt", text);
            }

        }

        // DELETE api/<UserController>/
        public void Delete(int id)
        {

        }


    }
}