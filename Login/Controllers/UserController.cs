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
        public async Task<User> Get(int id)
        {
            return await _UserService.GetUserById(id);
            

        }

        // POST api/<UserController>
        [HttpPost]
       
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            return await _UserService.CreatUser(user);
           


        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login([FromBody] User detailsofuser)
        {
            return await _UserService.Login(detailsofuser);
           


        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
             await _UserService.UpdateUserById(id, userToUpdate);
           

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _UserService.Delete(id);
        }
    }
}
