using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Login;
using Services;
using Entity;
using DTO;
using NLog.Web;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _UserService;
        IMapper _mapper;
        ILogger<UserController> _logger;

        public UserController(IUserService UserService, IMapper mapper, ILogger<UserController> logger)
        {
            _UserService = UserService;
            _mapper = mapper;
            _logger =logger;
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
        public async Task<UserDto> Get(int id)
        {

            User user= await _UserService.GetUserById(id);
            UserDto userDto= _mapper.Map<User, UserDto>(user);
            return userDto;

        }

        // POST api/<UserController>
        [HttpPost]
       
        public async Task<ActionResult<UserDto>> Post([FromBody] UserWithPasswordDto userWithPasswordDto)
        {
            
            User user= _mapper.Map<UserWithPasswordDto, User>(userWithPasswordDto);
            User user2 = await _UserService.CreatUser(user);
            if (user2 == null)
                return BadRequest();

            _logger.LogInformation($"Register attempted with User Name {user2.FirstName} {user2.LastName} with passward{user2.Password}");
            UserDto userDto= _mapper.Map<User, UserDto>(user2);
            return userDto;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] UserWithPasswordDto detailsofuser)
        {
            
            User user = _mapper.Map<UserWithPasswordDto, User>(detailsofuser);
            User user2 = await _UserService.Login(user);
            _logger.LogInformation($"Login user with email {user2.Email} with passward{user2.Password}");
            UserDto userDto = _mapper.Map<User, UserDto>(user2);
            return userDto;

        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserWithPasswordDto userToUpdate)
        {
            User user = _mapper.Map<UserWithPasswordDto, User>(userToUpdate);
            await _UserService.UpdateUserById(id, user);
           

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _UserService.Delete(id);
        }
    }
}
