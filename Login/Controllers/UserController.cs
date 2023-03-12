using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Login;
using Services;
using Entity;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }


        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _UserService.GetAllUsers();
           // return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _UserService.GetUserById(id);
            

        }

        // POST api/<UserController>
        [HttpPost]
       
        public User Post([FromBody] User user)
        {
            return _UserService.CreatUser(user);
           


        }
        [HttpPost]
        [Route("login")]
        public User Login([FromBody] User detailsofuser)
        {
            return _UserService.Login(detailsofuser);
           


        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
             _UserService.UpdateUserById(id, userToUpdate);
           

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
